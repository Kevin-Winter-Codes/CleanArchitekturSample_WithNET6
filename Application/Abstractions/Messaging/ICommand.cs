using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Messaging
{
    /*
     * MediatR verwendet die IRequest-Schnittstelle, 
     * um sowohl einen Befehl als auch eine Abfrage darzustellen. 
     * Für unseren Anwendungsfall erstellen wir separate Abstraktionen für Befehle und Abfragen. 
     */
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
