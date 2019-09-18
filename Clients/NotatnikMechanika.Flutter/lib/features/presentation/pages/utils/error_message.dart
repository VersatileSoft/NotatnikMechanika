import 'package:flutter/material.dart';

class ErrorMessage extends StatelessWidget {
  final String message;
  final bool show;
  const ErrorMessage({Key key, this.message, this.show}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      child: Opacity(
          opacity: show ? 1.0 : 0.0,
          child: Container(
            margin: EdgeInsets.only(top: 20),
            child: Text(message,
                textAlign: TextAlign.center,
                style: TextStyle(
                    color: Colors.red,
                    fontSize: 20,
                    fontWeight: FontWeight.bold)),
          )),
    );
  }
}
