/// yunus emre düşmez iletişim: ydmez6@gmail.com - facebook.com/ynu5
#include <IRremote.h>
int INFRARED_PIN = 2;  
decode_results results;
IRrecv irrecv(INFRARED_PIN);
void setup() {

  irrecv.enableIRIn();
  Serial.begin(9600);
}

void loop() {
 
  if (irrecv.decode(&results)) {  
    Serial.println(results.value);  
    irrecv.resume();  
  }
}
