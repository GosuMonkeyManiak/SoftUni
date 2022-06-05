function attachEventsListeners() {
    document.getElementById('convert').addEventListener('click', e => {
        let from = document.getElementById('inputUnits').value;
        let to = document.getElementById('outputUnits').value;
        let valueToConvert = Number(document.getElementById('inputDistance').value);
        let convertedValue = 0;

        if (from == 'km') {

            if (to == 'km') {
                convertedValue = valueToConvert;
            } else if (to == 'm') {
                convertedValue = valueToConvert * 1000;
            } else if (to == 'cm') {
                convertedValue = valueToConvert * 100000;
            } else if (to == 'mm') {
                convertedValue = valueToConvert * 1000000;
            } else if (to == 'mi') {
                convertedValue = valueToConvert * 0.621371;
            } else if (to == 'yrd') {
                convertedValue = valueToConvert * 1093.61;
            } else if (to == 'ft') {
                convertedValue = valueToConvert * 3280.84;
            } else if (to == 'in') {
                convertedValue = valueToConvert * 39370.1;
            }

        } else if (from == 'm') {

            if (to == 'km') {
                convertedValue = valueToConvert / 1000;
            } else if (to == 'm') {
                convertedValue = valueToConvert;
            } else if (to == 'cm') {
                convertedValue = valueToConvert * 100;
            } else if (to == 'mm') {
                convertedValue = valueToConvert * 1000;
            } else if (to == 'mi') {
                convertedValue = valueToConvert * 0.000621371;
            } else if (to == 'yrd') {
                convertedValue = valueToConvert * 1.09361;
            } else if (to == 'ft') {
                convertedValue = valueToConvert * 3.28084;
            } else if (to == 'in') {
                convertedValue = valueToConvert * 39.3701;
            }

        } else if (from == 'cm') {

            if (to == 'km') {
                convertedValue = valueToConvert / 100000;
            } else if (to == 'm') {
                convertedValue = valueToConvert / 100;
            } else if (to == 'cm') {
                convertedValue = valueToConvert;
            } else if (to == 'mm') {
                convertedValue = valueToConvert * 10;
            } else if (to == 'mi') {
                convertedValue = valueToConvert * 6.21371e-6;
            } else if (to == 'yrd') {
                convertedValue = valueToConvert * 0.0109361;
            } else if (to == 'ft') {
                convertedValue = valueToConvert * 0.0328084;
            } else if (to == 'in') {
                convertedValue = valueToConvert * 0.393701;
            }

        } else if (from == 'mm') {
            
            if (to == 'km') {
                convertedValue = valueToConvert / 1000000;
            } else if (to == 'm') {
                convertedValue = valueToConvert / 1000;
            } else if (to == 'cm') {
                convertedValue = valueToConvert / 10;
            } else if (to == 'mm') {
                convertedValue = valueToConvert;
            } else if (to == 'mi') {
                convertedValue = valueToConvert * 6.21371e-6;
            } else if (to == 'yrd') {
                convertedValue = valueToConvert * 0.00109361;
            } else if (to == 'ft') {
                convertedValue = valueToConvert * 0.00328084;
            } else if (to == 'in') {
                convertedValue = valueToConvert * 0.0393701;
            }

        } else if (from == 'mi') {
            
            if (to == 'km') {
                convertedValue = valueToConvert / 0.621371;
            } else if (to == 'm') {
                convertedValue = valueToConvert / 0.000621371;
            } else if (to == 'cm') {
                convertedValue = valueToConvert / 6.21371e-6;
            } else if (to == 'mm') {
                convertedValue = valueToConvert / 6.21371e-7;
            } else if (to == 'mi') {
                convertedValue = valueToConvert;
            } else if (to == 'yrd') {
                convertedValue = valueToConvert * 1760;
            } else if (to == 'ft') {
                convertedValue = valueToConvert * 5280;
            } else if (to == 'in') {
                convertedValue = valueToConvert * 63360;
            }

        } else if (from == 'yrd') {
            
            if (to == 'km') {
                convertedValue = valueToConvert / 1093.61;
            } else if (to == 'm') {
                convertedValue = valueToConvert / 1.09361;
            } else if (to == 'cm') {
                convertedValue = valueToConvert / 0.0109361;
            } else if (to == 'mm') {
                convertedValue = valueToConvert / 0.00109361;
            } else if (to == 'mi') {
                convertedValue = valueToConvert / 1760;
            } else if (to == 'yrd') {
                convertedValue = valueToConvert;
            } else if (to == 'ft') {
                convertedValue = valueToConvert * 3;
            } else if (to == 'in') {
                convertedValue = valueToConvert * 36;
            }

        } else if (from == 'ft') {
            
            if (to == 'km') {
                convertedValue = valueToConvert / 3280.84;
            } else if (to == 'm') {
                convertedValue = valueToConvert / 3.28084;
            } else if (to == 'cm') {
                convertedValue = valueToConvert / 0.0328084;
            } else if (to == 'mm') {
                convertedValue = valueToConvert / 0.00328084;
            } else if (to == 'mi') {
                convertedValue = valueToConvert / 5280;
            } else if (to == 'yrd') {
                convertedValue = valueToConvert / 3;
            } else if (to == 'ft') {
                convertedValue = valueToConvert;
            } else if (to == 'in') {
                convertedValue = valueToConvert * 12;
            }
            
        } else if (from == 'in') {
            
            if (to == 'km') {
                convertedValue = valueToConvert / 39370.1;
            } else if (to == 'm') {
                convertedValue = valueToConvert / 39.3701;
            } else if (to == 'cm') {
                convertedValue = valueToConvert / 0.393701;
            } else if (to == 'mm') {
                convertedValue = valueToConvert / 0.0393701;
            } else if (to == 'mi') {
                convertedValue = valueToConvert / 63360;
            } else if (to == 'yrd') {
                convertedValue = valueToConvert / 36;
            } else if (to == 'ft') {
                convertedValue = valueToConvert / 12;
            } else if (to == 'in') {
                convertedValue = valueToConvert;
            }
        }

        document.getElementById('outputDistance').value = convertedValue;
    })
}