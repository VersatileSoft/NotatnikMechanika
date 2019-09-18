import 'package:dartz/dartz.dart';
import 'package:notatnik_mechanika/core/error/failures.dart';
import 'package:notatnik_mechanika/core/usecases/usecase.dart';
import 'package:notatnik_mechanika/features/domain/entities/user/authenticate_user_model.dart';
import 'package:notatnik_mechanika/features/domain/entities/user/token.dart';
import 'package:notatnik_mechanika/features/domain/repositories/authetication_repository.dart';

class Login implements UseCase<Token, AuthenticateUserModel> {
  final AutheticationRepository repository;

  Login(this.repository);

  @override
  Future<Either<Failure, Token>> call(AuthenticateUserModel params) async {
    return await repository.login(params);
  }
}
