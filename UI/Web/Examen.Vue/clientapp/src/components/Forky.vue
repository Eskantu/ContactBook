<template>
  <v-card dark height="400">
    <v-card-text>
      <div class="forky">
        <div class="face"></div>
        <div class="face-mask1"></div>
        <div class="fork1"></div>
        <div class="fork2"></div>
        <div class="fork3"></div>
        <div class="fork4"></div>
        <div class="eye1"></div>
        <div class="eye2"></div>
        <div class="pupil1"></div>
        <div class="pupil2"></div>
        <div class="mouth1"></div>
        <div class="mouth2"></div>
        <div class="brow"></div>
      </div>
    </v-card-text>
  </v-card>
</template>

<script>
export default {
  name: "Forky",
};
</script>

<style scoped>
.forky {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
}
.face {
  width: 300px;
  height: 300px;
  background: #f0f0f0;
  position: absolute;
  border-radius: 65% 30% 65% 28%;
  transform: rotate(-45deg);
  top: -135px;
  left: -147px;
}
.face-mask1 {
  width: 300px;
  height: 60px;
  position: absolute;
  top: -160px;
  left: -147px;
}
.fork1,
.fork4 {
  width: 193px;
  height: 189px;
  background: #f0f0f0;
  border-radius: 100% 0% 97% 3% / 91% 0% 99% 3%;
  transform: rotate(-44deg);
  position: absolute;
  top: -121px;
  left: -159px;
}
.fork2,
.fork3 {
  width: 122px;
  height: 77px;
  background: #f0f0f0;
  position: absolute;
  top: -141px;
  left: -88px;
  border-radius: 100% 0% 86% 14% / 98% 0% 100% 2%;
  transform: rotate(128deg);
}
.fork3 {
  left: -34px;
  transform: rotate(50deg) rotateY(180deg);
}
.fork4 {
  left: -37px;
  transform: rotate(45deg) rotateY(180deg);
}
.eye1 {
  width: 110px;
  height: 110px;
  background: white;
  position: absolute;
  border-radius: 50%;
  top: -51px;
  left: -99px;
  box-shadow: 1px 1px 3px #888787; /*X,Y,blur*/
}
.pupil1 {
  width: 70px;
  height: 70px;
  background: black;
  border-radius: 50%;
  position: absolute;
  top: -20px;
  right: 25px;
  box-shadow: 1px 1px 3px #888787;
}
.eye2 {
  width: 70px;
  height: 70px;
  background: white;
  border-radius: 50%;
  position: absolute;
  top: -20px;
  left: 20px;
  box-shadow: 1px 1px 1px #888787;
}
.pupil2 {
  width: 30px;
  height: 30px;
  background: black;
  border-radius: 50%;
  position: absolute;
  top: 10px;
  left: 30px;
}
.mouth1 {
  width: 120px;
  height: 81px;
  border: 15px solid #71acc8;
  position: absolute;
  top: 46px;
  left: -60px;
  border-radius: 42% 17% 70% 44% / 32% 26% 80% 73%;
  clip-path: polygon(0% 33%, 100% 11%, 99% 100%, 0% 100%);
}
.mouth2 {
  width: 144px;
  height: 81px;
  border: 15px solid #71acc8;
  border-radius: 42% 17% 70% 44% / 32% 26% 80% 73%;
  position: absolute;
  top: -6px;
  left: -78px;
  clip-path: polygon(0 83%, 100% 56%, 99% 100%, 0% 100%);
}
.brow {
  width: 150px;
  height: 51px;
  border: 25px solid #d70000;
  border-radius: 32% 43% 39% 52% / 28% 21% 86% 72%;
  position: absolute;
  top: -107px;
  left: -91px;
  clip-path: polygon(0 54%, 100% 39%, 99% 100%, 0% 100%);
  transform: rotate(196deg);
}
</style>