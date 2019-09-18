import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:notatnik_mechanika/bloc/authentication/authentication.dart';
import 'package:notatnik_mechanika/bloc/login/login.dart';
import 'package:notatnik_mechanika/pages/home/home.dart';
import 'package:notatnik_mechanika/pages/utils/button_indicator.dart';
import 'package:notatnik_mechanika/pages/utils/custom_input.dart';
import 'package:notatnik_mechanika/pages/utils/error_message.dart';
import 'package:notatnik_mechanika/pages/utils/photo_hero.dart';

class LoginForm extends StatefulWidget {
  @override
  State<LoginForm> createState() => _LoginFormState();
}

class _LoginFormState extends State<LoginForm> {
  final _emailController = TextEditingController();
  final _passwordController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    final loginBloc = BlocProvider.of<LoginBloc>(context);

    _onLoginButtonPressed() {
      loginBloc.dispatch(LoginButtonPressed(
        username: _emailController.text,
        password: _passwordController.text,
      ));
    }

    Widget _buildLoginForm() {
      return BlocListener<AuthenticationBloc, AuthenticationState>(
        listener: (context, state) {
          if (state is AuthenticationAuthenticated) {
            Navigator.pushReplacement(
                context, MaterialPageRoute(builder: (context) => HomePage()));
          }
        },
        child: BlocBuilder<LoginBloc, LoginState>(builder: (context, state) {
          return Column(children: <Widget>[
            Container(
                margin: EdgeInsets.only(bottom: 20),
                child: CustomInput(
                  obscureText: false,
                  controller: _emailController,
                  text: "Podaj email",
                )),
            CustomInput(
              controller: _passwordController,
              text: 'Podaj hasło',
              obscureText: true,
            ),
            Container(
                margin: EdgeInsets.only(top: 20),
                child: Center(
                    child: ButtonIndicator(
                  onPressed: _onLoginButtonPressed,
                  isBusy: state is LoginLoading,
                  text: "zaloguj",
                ))),
            ErrorMessage(
              message: "Nieprawidłowy login lub hasło",
              show: state is LoginFailure,
            )
          ]);
        }),
      );
    }

    return ListView(
      children: <Widget>[
        Container(
            alignment: Alignment.topCenter,
            margin: EdgeInsets.only(top: 100, left: 50, right: 50),
            child: PhotoHero(
              width: 100,
              photo: 'assets/icon.png',
            )),
        Container(
            margin: EdgeInsets.only(top: 100, left: 50, right: 50),
            alignment: Alignment.bottomCenter,
            child: _buildLoginForm())
      ],
    );
  }
}
