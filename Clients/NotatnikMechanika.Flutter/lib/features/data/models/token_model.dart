import 'package:meta/meta.dart';
import 'package:notatnik_mechanika/features/domain/entities/user/token.dart';

class TokenModel extends Token {
  TokenModel({@required String token}) : super(token: token);

  factory TokenModel.fromJson(Map<String, dynamic> json) =>
      TokenModel(token: json['token']);

  Map<String, dynamic> toJson() => {'token': token};
}
