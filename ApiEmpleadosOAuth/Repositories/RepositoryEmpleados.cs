﻿using ApiEmpleadosOAuth.Data;
using ApiEmpleadosOAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpleadosOAuth.Repositories
{
    public class RepositoryEmpleados
    {
        EmpleadosContext context;
        public RepositoryEmpleados(EmpleadosContext context)
        {
            this.context = context;
        }

        public List<Empleado> GetEmpleados()
        {
            return this.context.Empleados.ToList();
        }

        public List<Empleado> GetEmpleadosOficio(string oficio)
        {
            return this.context.Empleados.Where(z => z.Oficio == oficio).ToList();
        }

        public Empleado BuscarEmpleado(int idempleado)
        {
            return this.context.Empleados
                .SingleOrDefault(x => x.IdEmpleado == idempleado);
        }

        public Empleado ExisteEmpleado(String apellido, int idempleado)
        {
            return this.context.Empleados
                .SingleOrDefault(x => x.Apellido == apellido
                && x.IdEmpleado == idempleado);
        }

        public List<Empleado> GetSubordinados(int idempleado)
        {
            return this.context.Empleados
                .Where(x => x.Director == idempleado).ToList();
        }
    }
}
