"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.useLoginRoute = void 0;
function useLoginRoute(fastify) {
    fastify.get('/login', async (req, res) => {
        return 'login';
    });
}
exports.useLoginRoute = useLoginRoute;
