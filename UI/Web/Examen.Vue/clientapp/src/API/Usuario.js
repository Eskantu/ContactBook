import request from "./request"


class Usuario{
  static Obtener(){
    return request.GET('Usuario')
  }
  static Eliminar(idUsuario) {
    return request.DELETE('Usuario', idUsuario)
  }
  static Actualizar(usuario) {
    return request.PUT('Usuario','', usuario)
  }
}

export default Usuario