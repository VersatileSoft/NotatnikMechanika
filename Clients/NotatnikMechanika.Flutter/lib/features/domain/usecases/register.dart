import 'package:dartz/dartz.dart';
import 'package:notatnik_mechanika/core/error/failures.dart';
import 'package:notatnik_mechanika/core/usecases/usecase.dart';
import 'package:notatnik_mechanika/features/domain/entities/succes_response.dart';
import 'package:notatnik_mechanika/features/domain/entities/user/create_user_model.dart';
import 'package:notatnik_mechanika/features/domain/repositories/authetication_repository.dart';

class Register implements UseCase<SuccesResponse, CreateUser> {
  final AutheticationRepository repository;

  Register(this.repository);

  @override
  Future<Either<Failure, SuccesResponse>> call(CreateUser params) async {
    return await repository.register(params);
  }
}
