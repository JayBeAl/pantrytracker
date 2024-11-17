import {BarcodeFormat, BrowserMultiFormatReader, DecodeHintType} from '@zxing/library';

let codeReader;
let dotNetHelper;
let isProcessingEnabled = true;

async function requestCameraPermission() {
    try {
        await navigator.mediaDevices.getUserMedia({
            video: {
                facingMode: 'environment',
                width: { ideal: 1280 },
                height: { ideal: 720 }
            }
        });
        return true;
    } catch (err) {
        console.error('Camera permission denied:', err);
        return false;
    }
}

export async function startScanning(helper) {
    console.log('Starting scanner...');

    // Reset any existing scanner
    if (codeReader) {
        codeReader.reset();
        codeReader = null;
    }

    if (!await requestCameraPermission()) {
        return;
    }

    dotNetHelper = helper;
    const hints = new Map();
    hints.set(DecodeHintType.POSSIBLE_FORMATS, [
        BarcodeFormat.EAN_13,
        BarcodeFormat.EAN_8,
        BarcodeFormat.UPC_A,
        BarcodeFormat.UPC_E
    ]);

    codeReader = new BrowserMultiFormatReader(hints);

    try {
        const videoInputDevices = await codeReader.listVideoInputDevices();
        console.log('Available devices:', videoInputDevices);

        const selectedDeviceId = videoInputDevices[videoInputDevices.length - 1].deviceId;
        startDecoding(selectedDeviceId);
    } catch (err) {
        console.error('Error starting scanner:', err);
    }
}

function startDecoding(selectedDeviceId) {
    codeReader.decodeFromVideoDevice(selectedDeviceId, 'video', (result, err) => {
        if (result && isProcessingEnabled) {
            console.log('Barcode detected:', result.text);
            dotNetHelper.invokeMethodAsync('OnBarcode', result.text);
        }
        if (err && !(err.name === 'NotFoundException')) {
            console.error('Decoding error:', err);
        }
    });
}

export function stopScanning() {
    if (codeReader) {
        codeReader.reset();
        codeReader = null;
    }
}

export function pauseScanning() {
    isProcessingEnabled = false;
}

export function resumeScanning() {
    isProcessingEnabled = true;
}
