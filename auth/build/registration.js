"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.useRegistrationRoute = void 0;
function useRegistrationRoute(fastify) {
    fastify.get('/registration', async (req, res) => {
        return 'registration';
    });
}
exports.useRegistrationRoute = useRegistrationRoute;
