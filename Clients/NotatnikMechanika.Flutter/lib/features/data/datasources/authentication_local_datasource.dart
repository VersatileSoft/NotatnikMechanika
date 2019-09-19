import 'package:notatnik_mechanika/features/data/models/token_model.dart';
import 'package:notatnik_mechanika/features/domain/entities/user/token.dart';

abstract class AuthenticationLocalDataSource {
  /// Get cached token
  ///
  /// Throws a [CacheException] if token not exsist
  Future<TokenModel> get token;

  /// Cache Token
  Future cacheToken(Token token);
}
