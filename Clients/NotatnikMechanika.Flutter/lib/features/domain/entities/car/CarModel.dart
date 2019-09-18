import 'package:equatable/equatable.dart';

class CarModel extends Equatable {
  final int id;
  final String brand;
  final String plate; //Rejestracja
  final String engine;
  final String power;
  final String vin;
  final int customerId;

  CarModel({
    this.id,
    this.brand,
    this.plate,
    this.engine,
    this.power,
    this.vin,
    this.customerId,
  }) : super([id, brand, plate, engine, power, vin, customerId]);
}
