import request from "./request"

class TipoContacto {
  static Obtener() {
    return request.GET('TipoContacto')
  }
  static Eliminar(idTipoContacto) {
    return request.DELETE('TipoContacto', idTipoContacto)
  }
  static Actualizar(tipoContacto) {
    return request.PUT('TipoContacto','', tipoContacto)
  }
  static Crear(tipoContacto) {
    return request.POST('TipoContacto','', tipoContacto)
  }
}
export default TipoContacto