import resolve from '@rollup/plugin-node-resolve';
import commonjs from '@rollup/plugin-commonjs';

export default {
    input: './wwwroot/js/barcodeScanner.js',
    output: {
        file: './wwwroot/js/bundle.js',
        format: 'es'
    },
    plugins: [
        resolve(),
        commonjs()
    ]
};
