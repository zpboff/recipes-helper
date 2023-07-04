import { FastifyInstance } from 'fastify'

export function useLoginRoute(fastify: FastifyInstance) {
    fastify.get('/login', async (req, res) => {
        return 'login'
    });
}