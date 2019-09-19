import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/mockito.dart';
import 'package:notatnik_mechanika/core/error/exceptions.dart';
import 'package:notatnik_mechanika/core/error/failures.dart';
import 'package:notatnik_mechanika/features/data/datasources/authentication_local_datasource.dart';
import 'package:notatnik_mechanika/features/data/datasources/authentication_remote_datasource.dart';
import 'package:notatnik_mechanika/features/data/models/token_model.dart';
import 'package:notatnik_mechanika/features/data/repositories/authetication_repository_impl.dart';
import 'package:notatnik_mechanika/features/domain/entities/succes_response.dart';
import 'package:notatnik_mechanika/features/domain/entities/user/authenticate_user_model.dart';
import 'package:notatnik_mechanika/features/domain/entities/user/create_user_model.dart';

class MockAuthenticationLocalDataSource extends Mock
    implements AuthenticationLocalDataSource {}

class MockAuthenticationRemoteDataSource extends Mock
    implements AuthenticationRemoteDataSource {}

main() {
  AuthenticationRepositoryImpl authenticationRepositoryImpl;
  MockAuthenticationLocalDataSource mockAuthenticationLocalDataSource;
  MockAuthenticationRemoteDataSource mockAuthenticationRemoteDataSource;
  TokenModel fakeToken = TokenModel(token: "abcd");
  AuthenticateUser fakeUser = AuthenticateUser(
    email: "fake",
    password: "fake",
  );

  CreateUser fakeCreateUser = CreateUser(
    email: "fake",
    password: "fake",
    name: "fake",
    surname: "fake",
  );

  setUp(() {
    mockAuthenticationLocalDataSource = MockAuthenticationLocalDataSource();
    mockAuthenticationRemoteDataSource = MockAuthenticationRemoteDataSource();

    authenticationRepositoryImpl = AuthenticationRepositoryImpl(
        authenticationLocalDataSource: mockAuthenticationLocalDataSource,
        authenticationRemoteDataSource: mockAuthenticationRemoteDataSource);
  });

  _gettingTokenFromLocal(Function body) {
    group("Getting token from local storage", body);
  }

  _gettingTokenFromRemote(Function body) {
    group("Getting token from remote", body);
  }

  _register(Function body) {
    group("Register new user", body);
  }

  _gettingTokenFromLocal(() {
    test('Should get exsisting [Token]', () async {
      // arrange
      when(mockAuthenticationLocalDataSource.token)
          .thenAnswer((_) async => fakeToken);
      // act
      final result = await authenticationRepositoryImpl.token;
      // assert
      expect(result, Right(fakeToken));
      verify(mockAuthenticationLocalDataSource.token);
      verifyZeroInteractions(mockAuthenticationRemoteDataSource);
      verifyNoMoreInteractions(mockAuthenticationLocalDataSource);
    });

    test('Should return [Failure] if token not exsist', () async {
      // arrange
      when(mockAuthenticationLocalDataSource.token).thenThrow(CacheException());
      // act
      final result = await authenticationRepositoryImpl.token;
      // assert
      expect(result, Left(CacheFailure()));
      verify(mockAuthenticationLocalDataSource.token);
      verifyNoMoreInteractions(mockAuthenticationLocalDataSource);
      verifyZeroInteractions(mockAuthenticationRemoteDataSource);
    });
  });

  _gettingTokenFromRemote(() {
    test('Should return [Token] from remote datasource while login successful',
        () async {
      // arrange
      when(mockAuthenticationRemoteDataSource.login(any))
          .thenAnswer((_) async => fakeToken);
      // act
      final result = await authenticationRepositoryImpl.login(fakeUser);
      // assert
      expect(result, Right(fakeToken));
      verify(mockAuthenticationRemoteDataSource.login(fakeUser));
      verifyNoMoreInteractions(mockAuthenticationRemoteDataSource);
    });

    test('Should check if token was cached', () async {
      // arrange
      when(mockAuthenticationRemoteDataSource.login(any))
          .thenAnswer((_) async => fakeToken);
      // act
      await authenticationRepositoryImpl.login(fakeUser);
      // assert
      verify(mockAuthenticationLocalDataSource.cacheToken(fakeToken));
      verifyNoMoreInteractions(mockAuthenticationLocalDataSource);
    });

    test(
        'Should return [ServerFailure] from remote datasource while login unsuccesful',
        () async {
      // arrange
      when(mockAuthenticationRemoteDataSource.login(any))
          .thenThrow(RemoteFailure());
      // act
      final result = await authenticationRepositoryImpl.login(fakeUser);
      // assert
      expect(result, Left(RemoteFailure()));
      verify(mockAuthenticationRemoteDataSource.login(fakeUser));
      verifyNoMoreInteractions(mockAuthenticationRemoteDataSource);
      verifyZeroInteractions(mockAuthenticationLocalDataSource);
    });
  });

  _register(() {
    test(
        'Should return [SuccesResponse] from remote datasource while registration success',
        () async {
      // arrange
      when(mockAuthenticationRemoteDataSource.register(any))
          .thenAnswer((_) async => SuccesResponse());
      // act
      final result =
          await authenticationRepositoryImpl.register(fakeCreateUser);
      // assert
      expect(result, Right(SuccesResponse()));
      verify(mockAuthenticationRemoteDataSource.register(fakeCreateUser));
      verifyNoMoreInteractions(mockAuthenticationRemoteDataSource);
      verifyZeroInteractions(mockAuthenticationLocalDataSource);
    });

    test(
        'Should return [RemoteFailure] from remote datasource while registration failure',
        () async {
      // arrange
      when(mockAuthenticationRemoteDataSource.register(any))
          .thenThrow(RemoteFailure());
      // act
      final result =
          await authenticationRepositoryImpl.register(fakeCreateUser);
      // assert
      expect(result, Left(RemoteFailure()));
      verify(mockAuthenticationRemoteDataSource.register(fakeCreateUser));
      verifyNoMoreInteractions(mockAuthenticationRemoteDataSource);
      verifyZeroInteractions(mockAuthenticationLocalDataSource);
    });
  });
}
