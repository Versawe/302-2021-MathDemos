float valStart = 0;
float valEnd = 500;

float animLength = 5;
float animTimer = 0;
boolean isPlaying = false;

float prevTime = 0;

void setup(){
  //screen size
  size(500,500);
}

void draw()
{
  //bg
  background(128);
  
  //delta time
  float currentTime = millis()/ 1000.0;
  float dt = currentTime - prevTime;
  prevTime = currentTime;
  
  //move playhead forward in time
  
  if(isPlaying) {
    animTimer += dt;
    if(animTimer >= animLength){
      isPlaying = false;
      animTimer = animLength;
    } 
  }
  //percent
  float p = animTimer / animLength;
  //manipulate p
  //p = p * p; //bends curve down - easing in
  //p = 1 - p; // plays backwards
  //p = 1- (1-p) * (1-p); //bends curve up - ease out
  p = p * p * (3-2*p); //smooth-step
  
  float x = lerp(valStart, valEnd, p);
  //draw circle
  ellipse(x, height/2.0, 20, 20);
  
}
//mouse click
void mousePressed()
{
 animTimer = 0;
 isPlaying = true;
}
