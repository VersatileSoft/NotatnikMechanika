class ServerException implements Exception {
  int statusCode;
  String message;

  ServerException({this.statusCode, this.message});
}

class CacheException implements Exception {}
