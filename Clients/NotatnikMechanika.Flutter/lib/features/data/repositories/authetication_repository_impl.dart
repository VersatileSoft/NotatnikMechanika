import 'package:dartz/dartz.dart';
import 'package:notatnik_mechanika/core/error/failures.dart';
import 'package:notatnik_mechanika/features/domain/entities/succes_response.dart';
import 'package:notatnik_mechanika/features/domain/entities/user/authenticate_user_model.dart';
import 'package:notatnik_mechanika/features/domain/entities/user/create_user_model.dart';
import 'package:notatnik_mechanika/features/domain/entities/user/token.dart';
import 'package:notatnik_mechanika/features/domain/repositories/authetication_repository.dart';

class AuthenticationRepositoryImpl implements AutheticationRepository{
  @override
  Future<Either<Failure, Token>> login(AuthenticateUser authenticateUserModel) {
    // TODO: implement login
    return null;
  }

  @override
  Future<Either<Failure, SuccesResponse>> register(CreateUser createUserModel) {
    // TODO: implement register
    return null;
  }

}