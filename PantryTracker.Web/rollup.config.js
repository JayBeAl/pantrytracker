import resolve from '@rollup/plugin-node-resolve';
import commonjs from '@rollup/plugin-commonjs';

export default {
    input: [
        './wwwroot/js/barcodeScanner.js',
        './wwwroot/js/scanningSession.js'
    ],
    output: {
        dir: './wwwroot/js/dist',
        format: 'es'
    },
    plugins: [
        resolve(),
        commonjs()
    ]
};
