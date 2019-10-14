import 'package:flutter/material.dart';

import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:notatnik_mechanika/features/presentation/bloc/authentication/authentication.dart';
import 'package:notatnik_mechanika/features/presentation/pages/login/login_page.dart';

import '../app_drawer.dart';

class HomePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    final AuthenticationBloc authenticationBloc =
        BlocProvider.of<AuthenticationBloc>(context);

    return BlocListener<AuthenticationBloc, AuthenticationState>(
      listener: (context, state) {
        if (state is AuthenticationUnauthenticated) {
          Navigator.pushReplacement(
              context, MaterialPageRoute(builder: (context) => LoginPage()));
        }
      },
      child: Scaffold(
        appBar: AppBar(
          title: Text('Home'),
        ),
        drawer: AppDrawer(),
        body: Container(
          child: Center(
              child: RaisedButton(
            child: Text('logout'),
            onPressed: () {
              authenticationBloc.dispatch(LogOut());
            },
          )),
        ),
      ),
    );
  }
}
