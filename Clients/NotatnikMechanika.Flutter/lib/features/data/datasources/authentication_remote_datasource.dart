import 'dart:convert';

import 'package:notatnik_mechanika/core/constants.dart';
import 'package:notatnik_mechanika/core/error/exceptions.dart';
import 'package:notatnik_mechanika/features/data/models/token_model.dart';
import 'package:notatnik_mechanika/features/domain/entities/user/authenticate_user_model.dart';
import 'package:notatnik_mechanika/features/domain/entities/user/create_user_model.dart';
import 'package:http/http.dart' as http;
import 'package:meta/meta.dart';

abstract class AuthenticationRemoteDataSource {
  /// Calls the login endpoint.
  ///
  /// Throws a [ServerException] for all error codes.
  Future<TokenModel> login(AuthenticateUser authenticateUserModel);

  /// Calls the register endpoint.
  ///
  /// Throws a [ServerException] for all error codes.
  Future register(CreateUser createUserModel);
}

class AuthenticationRemoteDataSourceImpl
    implements AuthenticationRemoteDataSource {
  final http.Client httpClient;

  AuthenticationRemoteDataSourceImpl({@required this.httpClient});

  @override
  Future<TokenModel> login(AuthenticateUser authenticateUserModel) async {
    final response =
        await httpClient.post(LOGIN_URL, body: authenticateUserModel);
    if (response.statusCode == 200) {
      final tokenModel = TokenModel.fromJson(json.decode(response.body));
      return tokenModel;
    } else {
      throw ServerException(
        statusCode: response.statusCode,
        message: response.body,
      );
    }
  }

  @override
  Future register(CreateUser createUserModel) async {
    final response = await httpClient.post(REGISTER_URL, body: createUserModel);
    if (response.statusCode != 200)
      throw ServerException(
        message: response.body,
        statusCode: response.statusCode,
      );
  }
}
