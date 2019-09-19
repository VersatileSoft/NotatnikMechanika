import 'package:meta/meta.dart';

class CreateUser {
  String password;
  String name;
  String surname;
  String email;

  CreateUser({
    @required this.password,
    @required this.name,
    @required this.surname,
    @required this.email,
  });
}
