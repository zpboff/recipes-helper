"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.registerLoginRoute = void 0;
function registerLoginRoute(fastify) {
    fastify.get('/login', async (req, res) => {
        return 'login';
    });
}
exports.registerLoginRoute = registerLoginRoute;
