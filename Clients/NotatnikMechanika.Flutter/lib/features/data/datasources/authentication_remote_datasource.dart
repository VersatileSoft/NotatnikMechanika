import 'package:notatnik_mechanika/features/data/models/token_model.dart';
import 'package:notatnik_mechanika/features/domain/entities/user/authenticate_user_model.dart';
import 'package:notatnik_mechanika/features/domain/entities/user/create_user_model.dart';

abstract class AuthenticationRemoteDataSource {
  /// Calls the login endpoint.
  ///
  /// Throws a [ServerException] for all error codes.
  Future<TokenModel> login(AuthenticateUserModel authenticateUserModel);

  /// Calls the register endpoint.
  ///
  /// Throws a [ServerException] for all error codes.
  Future register(CreateUserModel createUserModel);
}
