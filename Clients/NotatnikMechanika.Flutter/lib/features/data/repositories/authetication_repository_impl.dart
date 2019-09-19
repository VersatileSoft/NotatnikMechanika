import 'package:dartz/dartz.dart';
import 'package:notatnik_mechanika/core/error/failures.dart';
import 'package:notatnik_mechanika/features/data/datasources/authentication_local_datasource.dart';
import 'package:notatnik_mechanika/features/data/datasources/authentication_remote_datasource.dart';
import 'package:notatnik_mechanika/features/domain/entities/succes_response.dart';
import 'package:notatnik_mechanika/features/domain/entities/user/authenticate_user_model.dart';
import 'package:notatnik_mechanika/features/domain/entities/user/create_user_model.dart';
import 'package:notatnik_mechanika/features/domain/entities/user/token.dart';
import 'package:notatnik_mechanika/features/domain/repositories/authetication_repository.dart';
import 'package:meta/meta.dart';

class AuthenticationRepositoryImpl implements AutheticationRepository {
  final AuthenticationRemoteDataSource authenticationRemoteDataSource;
  final AuthenticationLocalDataSource authenticationLocalDataSource;

  AuthenticationRepositoryImpl({
    @required this.authenticationRemoteDataSource,
    @required this.authenticationLocalDataSource,
  });

  @override
  Future<Either<Failure, Token>> login(
      AuthenticateUser authenticateUserModel) async {
    try {
      final token =
          await authenticationRemoteDataSource.login(authenticateUserModel);
      await authenticationLocalDataSource.cacheToken(token);
      return Right(token);
    } catch (_) {
      return Left(RemoteFailure());
    }
  }

  @override
  Future<Either<Failure, SuccesResponse>> register(
      CreateUser createUserModel) async {
    try {
      await authenticationRemoteDataSource.register(createUserModel);
      return Right(SuccesResponse());
    } catch (_) {
      return Left(RemoteFailure());
    }
  }

  @override
  Future<Either<Failure, Token>> get token async {
    try {
      return Right(await authenticationLocalDataSource.token);
    } catch (_) {
      return Left(CacheFailure());
    }
  }
}
