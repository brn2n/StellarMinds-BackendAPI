using StellarMinds.LogicaNegocio.Entidades.Usuarios;
using StellarMinds.LogicaNegocio.Entidades.Equipos;

namespace StellarMinds.LogicaNegocio.Entidades.Prestamos
{
    public class Prestamo
    {
        public int Id { get; private set; }
        public DateTime FechaInicio { get; private set; }
        public DateTime FechaFin { get; private set; }

        public Socio Socio { get; private set; }
        public int SocioId { get; private set; }

        public Ocular Ocular { get; private set; }
        public int OcularId { get; private set; }

        public Telescopio Telescopio { get; private set; }
        public int TelescopioId { get; private set; }

        public Camara Camara { get; private set; }
        public int CamaraId { get; private set; }

        public Montura Montura { get; private set; }
        public int MonturaId { get; private set; }

        public Estado Estado { get; private set; } = Estado.EN_PRESTAMO;

        private Prestamo()
        {
        }

        public Prestamo(
            DateTime fechaFin,
            Socio socio,
            Montura montura,
            Ocular ocular,
            Telescopio telescopio,
            Camara camara,
            Estado estado)
        {
            FechaFin = fechaFin;
            FechaInicio = DateTime.Now;
            Socio = socio;
            Montura = montura;
            Ocular = ocular;
            Telescopio = telescopio;
            Camara = camara;
            Estado = estado;

            Validar();
        }

        private void Validar()
        {
            if (Socio == null)
                throw new ArgumentException("Debe indicarse el socio del préstamo.");

            if (FechaFin <= FechaInicio)
                throw new ArgumentException("La fecha de fin debe ser posterior a la fecha de inicio.");

            if (Camara == null && Ocular == null)
                throw new ArgumentException("Debe seleccionarse al menos una cámara o un ocular.");

            if (Camara != null)
            {
                if (Montura == null)
                    throw new ArgumentException("Debe seleccionarse una montura.");

                if (Montura.TipoMontura != TipoMontura.Ecuatorial &&
                    Montura.TipoMontura != TipoMontura.Hibrida)
                {
                    throw new ArgumentException("Para prestar una cámara, la montura debe ser ecuatorial o híbrida.");
                }
            }
        }

        public bool EstaVigente()
        {
            return Estado == Estado.EN_PRESTAMO && FechaFin >= DateTime.Today;
        }

        public void Devolver()
        {
            if (Estado != Estado.EN_PRESTAMO)
                throw new Exception("El préstamo no está en estado EN PRÉSTAMO.");

            Estado = Estado.DEVUELTO;
        }
    }
}