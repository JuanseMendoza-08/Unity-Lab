const int button1 = 7;
const int button2 = 3;
const int button3 = 4;
const int button4 = 5;
const int potPin = A0;

int previousState1 = HIGH;
int previousState2 = HIGH;
int previousState3 = HIGH;
int previousState4 = HIGH;

int lastPot = -1;

void setup() {
  Serial.begin(9600);

  pinMode(button1, INPUT_PULLUP);
  pinMode(button2, INPUT_PULLUP);
  pinMode(button3, INPUT_PULLUP);
  pinMode(button4, INPUT_PULLUP);
}

void loop() {
  readButton1();
  readButton2();
  readButton3();
  readButton4();
  readPotentiometer();

  delay(20);
}

void readButton1() {
  int currentState = digitalRead(button1);

  if (previousState1 == HIGH && currentState == LOW) {
    buttonFunction1();
  }

  previousState1 = currentState;
}

void readButton2() {
  int currentState = digitalRead(button2);

  if (previousState2 == HIGH && currentState == LOW) {
    buttonFunction2();
  }

  previousState2 = currentState;
}

void readButton3() {
  int currentState = digitalRead(button3);

  if (previousState3 == HIGH && currentState == LOW) {
    buttonFunction3();
  }

  previousState3 = currentState;
}

void readButton4() {
  int currentState = digitalRead(button4);

  if (previousState4 == HIGH && currentState == LOW) {
    buttonFunction4();
  }

  previousState4 = currentState;
}

void buttonFunction1() {
  Serial.println("BTN:1");
}

void buttonFunction2() {
  Serial.println("BTN:2");
}

void buttonFunction3() {
  Serial.println("BTN:3");
}

void buttonFunction4() {
  Serial.println("BTN:4");
}

void readPotentiometer() {
  int rawValue = analogRead(potPin);
  int mappedValue = map(rawValue, 0, 1023, 0, 100);

  if (mappedValue != lastPot) {
    Serial.print("POT:");
    Serial.println(mappedValue);
    lastPot = mappedValue;
  }
}