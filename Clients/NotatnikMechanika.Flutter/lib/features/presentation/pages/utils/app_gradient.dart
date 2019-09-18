import 'package:flutter/material.dart';

class AppGradient extends LinearGradient {
  AppGradient()
      : super(
        begin: Alignment.topRight, 
        end: Alignment.bottomLeft, 
        stops: [0,1], 
        colors: [
          Color(0xFF5877e6),
          Color(0xFF36dad2),
        ]);
}
