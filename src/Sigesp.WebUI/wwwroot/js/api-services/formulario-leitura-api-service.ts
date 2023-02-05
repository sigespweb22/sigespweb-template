export default {
  // Grupo Dica escrita
  dicaEscritaListaToSelectAsync: `${process.env.API_URL}/formularios-leituras/dicas-escrita/lista-to-select`,
  dicaEscritaAtivarAsync: `${process.env.API_URL}/formularios-leituras/dicas-escrita/ativar/`,
  dicaEscritaInativarAsync: `${process.env.API_URL}/formularios-leituras/dicas-escrita/inativar/`,

  // Dica escrita Dica
  dicaEscritaDicaNovoAsync: `${process.env.API_URL}/formularios-leituras/dicas-escrita/dicas/novo`,
  dicaEscritaDicaEdicaoAsync: `${process.env.API_URL}/formularios-leituras/dicas-escrita/dicas/edicao`,
  dicaEscritaDicaDeleteAsync: `${process.env.API_URL}/formularios-leituras/dicas-escrita/dicas/delete`,

  storageTokenKeyName: 'accessToken'
}