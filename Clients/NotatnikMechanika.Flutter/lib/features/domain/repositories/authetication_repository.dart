import 'package:dartz/dartz.dart';
import 'package:notatnik_mechanika/core/error/failures.dart';
import 'package:notatnik_mechanika/features/domain/entities/succes_response.dart';
import 'package:notatnik_mechanika/features/domain/entities/user/authenticate_user_model.dart';
import 'package:notatnik_mechanika/features/domain/entities/user/create_user_model.dart';
import 'package:notatnik_mechanika/features/domain/entities/user/token.dart';

abstract class AutheticationRepository {
  Future<Either<Failure, Token>> login(
      AuthenticateUserModel authenticateUserModel);

  Future<Either<Failure, SuccesResponse>> register(
      CreateUserModel createUserModel);
}
