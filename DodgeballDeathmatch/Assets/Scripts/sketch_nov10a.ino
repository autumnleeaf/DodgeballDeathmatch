const int joystick_x_pin = A4;  
const int joystick_y_pin = A5;
const int buttonPin1 = 5;
const int buttonPin2 = 8;

void setup()
{
 Serial.begin(9600);

  pinMode(buttonPin1, INPUT);
  pinMode(buttonPin2, INPUT);

  digitalWrite(buttonPin1, HIGH);
  digitalWrite(buttonPin2, HIGH);
}

void loop()
{
  int tmpGet = 0;
  int x_adc_val, y_adc_val; 
  float x_volt, y_volt;
  x_adc_val = analogRead(joystick_x_pin);
  y_adc_val = analogRead(joystick_y_pin);
  x_volt = ( ( x_adc_val * 3.3 ) / 1023 );  /*Convert digital value to voltage */
  y_volt = ( ( y_adc_val * 3.3 ) / 1023 );  /*Convert digital value to voltage */
  /*Serial.print("X_Voltage = ");
  Serial.print(x_volt);
  Serial.print("\t");
  Serial.print("Y_Voltage = ");
  Serial.println(y_volt);
  Serial.print("\t");*/

  // direction on x-axis
  if(x_volt < 1.00){
    tmpGet += 30; //right
    //Serial.print("x= right");
    //Serial.print(x_volt);
    //Serial.print("\t");
  }else if(x_volt > 2.00){
    tmpGet += 20; //left
    //Serial.print("x= left");
    //Serial.print(x_volt);
    //Serial.print("\t");
  }else{
    tmpGet += 10; //standing
    //Serial.print("x= standing");
    //Serial.print(x_volt);
    //Serial.print("\t");
  }

  // direction on y-axis
  if(y_volt < 1.00){
    tmpGet += 2; //down
    //Serial.print("y= up");
    //Serial.println(y_volt);
    //Serial.println("\t");
  }else if(y_volt > 2.00){
    tmpGet += 3; //up
    //Serial.print("y= down");
    //Serial.println(y_volt);
    //Serial.println("\t");
  }else{
    tmpGet += 1; //standing
    //Serial.print("y= standing");
    //Serial.println(y_volt);
    //Serial.println("\t");
  }

  if(digitalRead(buttonPin1) == HIGH)
  {
    tmpGet = 2;
    Serial.write(2);
    Serial.flush();
    delay(200);
  }
  if(digitalRead(buttonPin2) == HIGH)
  {
    tmpGet = 1;
    Serial.write(1);
    Serial.flush();
    delay(200);
  }
  //Serial.print(tmpGet);
  Serial.write(tmpGet);
  delay(10);
}
