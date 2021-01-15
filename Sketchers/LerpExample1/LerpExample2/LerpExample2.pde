
void setup(){
  size(500, 500);
}

void draw(){
   background(128);
   
   float p = mouseX / (float) width;
   float size = lerpy(50, 300, p);
   
   fill(p * 255);
   ellipse(width/2, height/2, size, size);
}

float lerpy(float min, float max, float p){
    return min + (max-min) * p;
}
