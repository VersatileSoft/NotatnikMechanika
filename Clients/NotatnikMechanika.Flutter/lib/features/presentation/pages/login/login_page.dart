import 'package:flutter/material.dart';
import 'package:notatnik_mechanika/features/presentation/pages/utils/app_gradient.dart';
import 'login_form.dart';

class LoginPage extends StatelessWidget {
  LoginPage({Key key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        child: LoginForm(),
        decoration: BoxDecoration(
          gradient: AppGradient(),
        ),
      ),
    );
  }
}
