import 'dart:convert';

import 'package:dartz/dartz.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/mockito.dart';
import 'package:notatnik_mechanika/core/error/exceptions.dart';
import 'package:notatnik_mechanika/features/data/datasources/authentication_local_datasource.dart';
import 'package:notatnik_mechanika/features/data/models/token_model.dart';
import 'package:shared_preferences/shared_preferences.dart';

class MockSharedPreferences extends Mock implements SharedPreferences {}

main() {
  AuthenticationLocalDataSource dataSource;
  MockSharedPreferences sharedPreferences;

  setUp(() {
    sharedPreferences = MockSharedPreferences();
    dataSource =
        AuthenticationLocalDataSourceImpl(sharedPreferences: sharedPreferences);
  });
  group('Should get token from local data', () {
    TokenModel model = TokenModel.fromJson(json.decode('{"token": "123"}'));
    test('Should return token when is in local storage', () async {
      // arrange
      when(sharedPreferences.getString(any)).thenReturn('{"token": "123"}');
      // act
      final result = await dataSource.getToken();
      // assert
      verify(sharedPreferences.getString(CACHED_TOKEN));
      expect(result, equals(model));
    });

    test('Should throw exception if token is not in local storage', () async {
       // arrange
      when(sharedPreferences.getString(any)).thenReturn(null);
      // act
      final call = dataSource.getToken;
      // assert
       expect(() => call(), throwsA(TypeMatcher<CacheException>()));
    });
  });
}