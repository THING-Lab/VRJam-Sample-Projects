var scene = document.querySelector('#scene');
var rightHand = document.querySelector('#right-controller');

rightHand.addEventListener('gripdown', function() {
    var newCylinder = document.createElement('a-cylinder');
    newCylinder.setAttribute('radius', 0.1);
    newCylinder.setAttribute('height', 0.5);
    newCylinder.setAttribute('color', '#FFDDDD');
    newCylinder.setAttribute('position', rightHand.object3D.position);
    newCylinder.setAttribute('rotation', rightHand.object3D.rotation);
    scene.appendChild(newCylinder);
});
