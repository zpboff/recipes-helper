import { FastifyInstance } from 'fastify';
import { LoginRequest, login } from '../services/login'

export function useLoginRoute(fastify: FastifyInstance) {
    fastify.post('/login', async (req, res) => {
        return await login(req.body as LoginRequest);
    });
}