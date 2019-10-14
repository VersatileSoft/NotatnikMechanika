import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:notatnik_mechanika/features/presentation/bloc/authentication/authentication.dart';

import 'features/presentation/bloc/authentication/authentication_bloc.dart';
import 'features/presentation/pages/splash/splash_page.dart';

void main() {
  runApp(
    BlocProvider<AuthenticationBloc>(
      builder: (context) {
        return AuthenticationBloc()..dispatch(AppStarted());
      },
      child: App(),
    ),
  );
}

class App extends StatelessWidget {
  App({Key key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(home: SplashPage());
  }
}
