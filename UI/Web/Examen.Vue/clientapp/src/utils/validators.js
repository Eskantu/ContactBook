export default {
  required: [(v) => !!v || "requerido"],
  min: [(v) => (!!v && v.length >= 8) || "minimo 8 caracteres"],
  max: [(v) => (!!v && v.length <= 12) || "maximo 12 caracteres"],
  email: [
    (v) =>
      /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(v) ||
      "email invalido",
  ],
  isSecuriryPassword: [
    (v) =>
      /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!.%*?&])[A-Za-z\d$@$!.%*?&]{8,}/.test(
        v
      ) || "contraseña no segura",
  ],
  same: [
    (v) => v === this.usuario.contrasenia || "contraseñas no coinciden",
  ],
};