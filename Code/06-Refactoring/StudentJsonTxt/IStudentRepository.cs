// <copyright file="IStudentRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace StudentJsonTxt
{
    using System.Collections.Generic;
    using StudentJsonTxt.Models;

    /// <summary>
    /// Дефинира общ интерфейс за запис и зареждане на ученици.
    /// Позволява използване на различни формати (TXT, JSON, XML).
    /// </summary>
    public interface IStudentRepository
    {
        /// <summary>
        /// Записва списък с ученици във външно хранилище.
        /// </summary>
        /// <param name="students">Списък с ученици.</param>
        void Save(List<Student> students);

        /// <summary>
        /// Зарежда списък с ученици от външно хранилище.
        /// </summary>
        /// <returns>Списък с ученици.</returns>
        List<Student> Load();
    }
}
