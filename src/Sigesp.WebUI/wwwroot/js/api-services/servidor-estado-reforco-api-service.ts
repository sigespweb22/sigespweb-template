export default {
    listMeAsync: `${process.env.API_URL}/servidores-estado-reforcos/list-me`,
    listWithUnavailableDatesAsync: `${process.env.API_URL}/servidores-estado-reforcos/list-with-unavailable-dates`,
    deleteByDateAsync: `${process.env.API_URL}/servidores-estado-reforcos/delete-by-data`,
    storageTokenKeyName: 'accessToken'
  }