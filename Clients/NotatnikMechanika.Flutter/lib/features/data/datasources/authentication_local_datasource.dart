import 'dart:convert';

import 'package:notatnik_mechanika/core/error/exceptions.dart';
import 'package:notatnik_mechanika/features/data/models/token_model.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:meta/meta.dart';

const CACHED_TOKEN = "CACHED_TOKEN";

abstract class AuthenticationLocalDataSource {
  /// Get cached token
  ///
  /// Throws a [CacheException] if token not exsist
  Future<TokenModel> getToken();

  /// Cache Token
  Future cacheToken(TokenModel token);
}

class AuthenticationLocalDataSourceImpl
    implements AuthenticationLocalDataSource {
  final SharedPreferences sharedPreferences;

  AuthenticationLocalDataSourceImpl({@required this.sharedPreferences});

  @override
  Future cacheToken(TokenModel token) async {
    return sharedPreferences.setString(
        CACHED_TOKEN, json.encode(token.toJson()));
  }

  @override
  Future<TokenModel> getToken() {
    String stringToken = sharedPreferences.getString(CACHED_TOKEN);
    if (stringToken != null) {
      return Future.value(TokenModel.fromJson(json.decode(stringToken)));
    } else {
      throw CacheException();
    }
  }
}
