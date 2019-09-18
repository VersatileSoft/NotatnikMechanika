import 'package:flutter/material.dart';

import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:notatnik_mechanika/bloc/authentication/authentication.dart';
import 'package:notatnik_mechanika/bloc/login/login.dart';
import 'package:notatnik_mechanika/pages/utils/app_gradient.dart';
import 'package:notatnik_mechanika/repositories/user_repository.dart';
import 'package:provider/provider.dart';

import 'login_form.dart';

class LoginPage extends StatelessWidget {
  LoginPage({Key key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final UserRepository userRepository = Provider.of<UserRepository>(context);
    return Scaffold(
      body: BlocProvider(
        builder: (context) {
          return LoginBloc(
            authenticationBloc: BlocProvider.of<AuthenticationBloc>(context),
            userRepository: userRepository,
          );
        },
        child: Container(
          child: LoginForm(),
          decoration: BoxDecoration(
            gradient: AppGradient(),
          ),
        ),
      ),
    );
  }
}
