import {defineConfig} from 'vite'
import react from '@vitejs/plugin-react-swc'
import dts from 'vite-plugin-dts';
import {libInjectCss} from 'vite-plugin-lib-inject-css';
import {extname, resolve, relative} from "path";
import {fileURLToPath} from "node:url"
import {glob} from 'glob';

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [
        react(),
        libInjectCss(),
        dts({include: ['lib']})
    ],
    build: {
        lib: {
            entry: resolve(__dirname, "lib/main.ts"),
            formats: ["es"]
        },
        rollupOptions: {
            external: ['react', 'react/jsx-runtime', "@radix-ui/themes"],
            input: Object.fromEntries(
                glob.sync('lib/**/*.{ts,tsx}', {ignore: ["lib/**/*.d.ts"],}).map(file => [
                    relative('lib', file.slice(0, file.length - extname(file).length)),
                    fileURLToPath(new URL(file, import.meta.url))]
                )
            ),
            output: {
                assetFileNames: 'assets/[name][extname]',
                entryFileNames: '[name].js',
            }
        }
    }
})
