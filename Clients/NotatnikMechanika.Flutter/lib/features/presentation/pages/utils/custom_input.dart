import 'package:flutter/material.dart';

class CustomInput extends StatelessWidget {
  final String text;
  final TextEditingController controller;
  final bool obscureText;

  CustomInput({this.controller, this.text, this.obscureText});

  @override
  Widget build(BuildContext context) {
    return new Container(
      child: new TextFormField(
        obscureText: obscureText,
        controller: controller,
        decoration: new InputDecoration(
          labelText: text,
          fillColor: Colors.white,
          border: new OutlineInputBorder(
            borderRadius: new BorderRadius.circular(8),
            borderSide: new BorderSide(),
          ),
        ),
        validator: (val) {
          if (val.length == 0) {
            return "Value cannot be empty";
          } else {
            return null;
          }
        },
        keyboardType:
            !obscureText ? TextInputType.emailAddress : TextInputType.text,
        style: new TextStyle(
          fontFamily: "Poppins",
        ),
      ),
    );
  }
}
