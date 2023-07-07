"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.useLoginRoute = void 0;
const login_1 = require("../services/login");
function useLoginRoute(fastify) {
    fastify.post('/login', async (req, res) => {
        const response = await (0, login_1.login)(req.body);
        return response;
    });
}
exports.useLoginRoute = useLoginRoute;
