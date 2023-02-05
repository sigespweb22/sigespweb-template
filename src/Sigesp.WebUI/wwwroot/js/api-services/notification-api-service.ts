export default {
  listaAsync: `${process.env.API_URL}/notifications/lista`,
  deleteAsync: `${process.env.API_URL}/notifications/delete/`,
  readAsync: `${process.env.API_URL}/notifications/read/`,
  storageTokenKeyName: 'accessToken'
}