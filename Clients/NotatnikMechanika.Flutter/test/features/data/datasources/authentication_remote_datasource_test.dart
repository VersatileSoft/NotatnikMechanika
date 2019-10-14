import 'dart:convert';

import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/mockito.dart';
import 'package:notatnik_mechanika/core/constants.dart';
import 'package:notatnik_mechanika/core/error/exceptions.dart';
import 'package:notatnik_mechanika/features/data/datasources/authentication_remote_datasource.dart';
import 'package:notatnik_mechanika/features/data/models/token_model.dart';
import 'package:http/http.dart' as http;
import 'package:notatnik_mechanika/features/domain/entities/user/authenticate_user_model.dart';
import 'package:notatnik_mechanika/features/domain/entities/user/create_user_model.dart';

import '../../../fixtures/fixture_reader.dart';

class MockHttpClient extends Mock implements http.Client {}

main() {
  AuthenticationRemoteDataSourceImpl dataSource;
  MockHttpClient client;

  setUp(() {
    client = MockHttpClient();
    dataSource = AuthenticationRemoteDataSourceImpl(httpClient: client);
  });
  group('login', () {
    final AuthenticateUser tAuthenticateUser = AuthenticateUser(
      email: '123@123.pl',
      password: '123',
    );

    final TokenModel token =
        TokenModel.fromJson(json.decode(fixture('token.json')));

    test(
      'should return token model when response from http post request is succes(200)',
      () async {
        //arrange
        when(client.post(any, body: anyNamed('body')))
            .thenAnswer((_) async => http.Response(fixture('token.json'), 200));
        // act
        final result = await dataSource.login(tAuthenticateUser);
        // assert
        verify(client.post(LOGIN_URL, body: tAuthenticateUser));
        expect(result, equals(token));
      },
    );

    test(
      'should throw a ServerException when the response code is 404 or other',
      () async {
        // arrange
        when(client.post(any, body: anyNamed('body')))
            .thenAnswer((_) async => http.Response('Fake error', 404));
        // act
        final call = dataSource.login;
        // assert
        expect(
          () => call(tAuthenticateUser),
          throwsA(predicate((response) =>
              response is ServerException &&
              response.message == 'Fake error' &&
              response.statusCode == 404)),
        );
      },
    );
  });

  group('register', () {
    final CreateUser tCreateUser = CreateUser(
      email: '123@123.pl',
      password: '123',
      name: 'test',
      surname: 'test',
    );

    test(
      'should call http POST with create user model',
      () async {
        //arrange
        when(client.post(any, body: anyNamed('body')))
            .thenAnswer((_) async => http.Response('ok response', 200));
        // act
        final call = dataSource.register;
        // assert
        expect(() => call(tCreateUser), returnsNormally);
        verify(client.post(REGISTER_URL, body: tCreateUser));
      },
    );

    test(
      'should throw a ServerException when the response code is 404 or other',
      () async {
        // arrange
        when(client.post(any, body: anyNamed('body')))
            .thenAnswer((_) async => http.Response('Fake error', 404));
        // act
        final call = dataSource.register;
        // assert
        expect(
          () => call(tCreateUser),
          throwsA(predicate((response) =>
              response is ServerException &&
              response.message == 'Fake error' &&
              response.statusCode == 404)),
        );
      },
    );
  });
}
