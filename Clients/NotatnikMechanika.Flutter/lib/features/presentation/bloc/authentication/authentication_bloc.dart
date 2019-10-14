import 'dart:async';
import 'package:bloc/bloc.dart';

import 'authentication.dart';

class AuthenticationBloc
    extends Bloc<AuthenticationEvent, AuthenticationState> {
  @override
  AuthenticationState get initialState => AuthenticationUninitialized();

  @override
  Stream<AuthenticationState> mapEventToState(
    AuthenticationEvent event,
  ) async* {
    if (event is AppStarted) {
      //final bool hasToken = await userRepository.hasToken();

      // if (hasToken) {
      //   yield AuthenticationAuthenticated();
      // } else {
      //   yield AuthenticationUnauthenticated();
      // }
    }

    if (event is LogIn) {
      // await userRepository.persistToken(event.token);
      yield AuthenticationAuthenticated();
    }

    if (event is LogOut) {
      // await userRepository.deleteToken();
      yield AuthenticationUnauthenticated();
    }
  }
}
