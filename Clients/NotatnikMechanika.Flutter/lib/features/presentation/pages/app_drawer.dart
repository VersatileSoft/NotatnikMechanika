import 'package:flutter/material.dart';
import 'package:notatnik_mechanika/features/presentation/pages/home/home_page.dart';
import 'package:notatnik_mechanika/features/presentation/pages/login/login_page.dart';

import 'splash/splash_page.dart';
import 'utils/app_gradient.dart';

class AppDrawer extends StatelessWidget {
  const AppDrawer({Key key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    Widget _buildItem({String text, IconData icon, Widget page}) {
      return Padding(
        padding: EdgeInsets.fromLTRB(0, 10, 0, 10),
        child: ListTile(
            title: Text(
              text,
              style: TextStyle(fontSize: 30, color: Colors.white),
            ),
            leading: Icon(
              icon,
              size: 30,
              color: Colors.white,
            ),
            onTap: () {
              Navigator.of(context).pushReplacement(
                  MaterialPageRoute(builder: (context) => page));
            }),
      );
    }

    return Drawer(
      child: Container(
        decoration: BoxDecoration(gradient: AppGradient()),
        child: ListView(
          padding: EdgeInsets.zero,
          children: <Widget>[
            DrawerHeader(
              child: Image.asset('assets/icon.png'),
              padding: EdgeInsets.all(30),
            ),
            _buildItem(
                icon: Icons.ac_unit, page: SplashPage(), text: "Zlecenia"),
            _buildItem(icon: Icons.person, page: HomePage(), text: "Klienci"),
            _buildItem(icon: Icons.person, page: LoginPage(), text: "Usługi"),
            _buildItem(icon: Icons.person, page: SplashPage(), text: "Magazyn"),
            _buildItem(
                icon: Icons.person, page: SplashPage(), text: "Archiwum"),
            _buildItem(
                icon: Icons.person,
                page: SplashPage(),
                text: "Faktury/Paragony"),
            _buildItem(icon: Icons.person, page: SplashPage(), text: "Wyloguj"),
          ],
        ),
      ),
    );
  }
}
