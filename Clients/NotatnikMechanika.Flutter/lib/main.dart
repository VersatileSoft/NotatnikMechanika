import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:notatnik_mechanika/features/presentation/bloc/authentication/authentication.dart';
import 'package:provider/provider.dart';

import 'features/presentation/bloc/authentication/authentication_bloc.dart';
import 'features/presentation/pages/splash/splash_page.dart';

void main() {
  final userRepository = UserRepository();
  runApp(
    BlocProvider<AuthenticationBloc>(
      builder: (context) {
        return AuthenticationBloc(userRepository: userRepository)
          ..dispatch(AppStarted());
      },
      child: App(userRepository: userRepository),
    ),
  );
}

class App extends StatelessWidget {
  final UserRepository userRepository;

  App({Key key, @required this.userRepository}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Provider<UserRepository>(
        builder: (context) => userRepository,
        dispose: (context, value) => value.dispose(),
        child: MaterialApp(home: SplashPage()));
  }
}
