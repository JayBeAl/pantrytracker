const successSound = new Audio('/sounds/beep-success.mp3');

function playSuccessSound() {
    successSound.play().catch(err => console.log('Sound playback failed:', err));
}

export { playSuccessSound };
