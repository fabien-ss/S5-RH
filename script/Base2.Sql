

CREATE TABLE public.avantage_employe (
                                         id_employe integer,
                                         id_avantage integer
);


ALTER TABLE public.avantage_employe OWNER TO postgres;

--
-- Name: details_contrat; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.details_contrat (
                                        id_details_contrat serial NOT NULL,
                                        date_debut date,
                                        date_fin date,
                                        id_contrat integer
);


ALTER TABLE public.details_contrat OWNER TO postgres;

--
-- Name: employe; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.employe (
                                id_employe serial NOT NULL,
                                id_candidature integer REFERENCES candidature(id_candidature),
                                id_details_contrat integer,
                                id_poste integer,
                                id_fiche_de_poste integer,
                                id_horaire integer,
                                id_avantage integer
);


ALTER TABLE public.employe OWNER TO postgres;

--
-- Name: fiche_de_poste; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.fiche_de_poste (
                                       id_fiche_de_poste serial NOT NULL,
                                       id_superieur integer,
                                       id_subordonnee character varying
);


ALTER TABLE public.fiche_de_poste OWNER TO postgres;

--
-- Name: horaire; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.horaire (
                                id_horaire serial NOT NULL,
                                jour character varying(500),
                                entree character varying,
                                sortie character varying
);


ALTER TABLE public.horaire OWNER TO postgres;

--
-- Name: mission; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.mission (
                                id_mission serial NOT NULL,
                                nom character varying(500)
);


ALTER TABLE public.mission OWNER TO postgres;

--
-- Name: mission_employe; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.mission_employe (
                                        id_fiche_de_poste integer,
                                        id_mission integer
);


ALTER TABLE public.mission_employe OWNER TO postgres;

--
-- Name: tache; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tache (
                              id_tache serial NOT NULL,
                              nom character varying,
                              id_mission integer
);


ALTER TABLE public.tache OWNER TO postgres;

--
-- Name: type_avantage; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.type_avantage (
                                      id_avantage serial NOT NULL,
                                      nom character varying(500)
);


ALTER TABLE public.type_avantage OWNER TO postgres;

--
-- Name: type_contrat; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.type_contrat (
                                     id_contrat serial NOT NULL,
                                     nom character varying(500)
);


ALTER TABLE public.type_contrat OWNER TO postgres;

--
-- Data for Name: avantage_employe; Type: TABLE DATA; Schema: public; Owner: postgres
--

--
-- Name: details_contrat pk_details_contrat; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.details_contrat
    ADD CONSTRAINT pk_details_contrat PRIMARY KEY (id_details_contrat);


--
-- Name: employe pk_employe; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employe
    ADD CONSTRAINT pk_employe PRIMARY KEY (id_employe);


--
-- Name: fiche_de_poste pk_fiche_de_poste; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.fiche_de_poste
    ADD CONSTRAINT pk_fiche_de_poste PRIMARY KEY (id_fiche_de_poste);


--
-- Name: horaire pk_horaire; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.horaire
    ADD CONSTRAINT pk_horaire PRIMARY KEY (id_horaire);


--
-- Name: mission pk_mission; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.mission
    ADD CONSTRAINT pk_mission PRIMARY KEY (id_mission);


--
-- Name: tache pk_tache; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tache
    ADD CONSTRAINT pk_tache PRIMARY KEY (id_tache);


--
-- Name: type_avantage pk_type_avantage; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.type_avantage
    ADD CONSTRAINT pk_type_avantage PRIMARY KEY (id_avantage);


--
-- Name: type_contrat pk_type_contrat; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.type_contrat
    ADD CONSTRAINT pk_type_contrat PRIMARY KEY (id_contrat);


--
-- Name: details_contrat unq_details_contrat_id_details_contrat; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.details_contrat
    ADD CONSTRAINT unq_details_contrat_id_details_contrat UNIQUE (id_details_contrat, id_contrat);


--
-- Name: avantage_employe fk_avantage_employe; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.avantage_employe
    ADD CONSTRAINT fk_avantage_employe FOREIGN KEY (id_avantage) REFERENCES public.type_avantage(id_avantage);


--
-- Name: avantage_employe fk_avantage_employe_employe; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.avantage_employe
    ADD CONSTRAINT fk_avantage_employe_employe FOREIGN KEY (id_employe) REFERENCES public.employe(id_employe);


--
-- Name: details_contrat fk_details_contrat; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.details_contrat
    ADD CONSTRAINT fk_details_contrat FOREIGN KEY (id_contrat) REFERENCES public.type_contrat(id_contrat);


--
-- Name: employe fk_employe_details_contrat; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employe
    ADD CONSTRAINT fk_employe_details_contrat FOREIGN KEY (id_details_contrat) REFERENCES public.details_contrat(id_details_contrat);


--
-- Name: employe fk_employe_fiche_de_poste; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employe
    ADD CONSTRAINT fk_employe_fiche_de_poste FOREIGN KEY (id_fiche_de_poste) REFERENCES public.fiche_de_poste(id_fiche_de_poste);


--
-- Name: employe fk_employe_horaire; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employe
    ADD CONSTRAINT fk_employe_horaire FOREIGN KEY (id_horaire) REFERENCES public.horaire(id_horaire);


--
-- Name: mission_employe fk_mission_employe; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.mission_employe
    ADD CONSTRAINT fk_mission_employe FOREIGN KEY (id_fiche_de_poste) REFERENCES public.fiche_de_poste(id_fiche_de_poste);


--
-- Name: mission_employe fk_mission_employe_mission; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.mission_employe
    ADD CONSTRAINT fk_mission_employe_mission FOREIGN KEY (id_fiche_de_poste) REFERENCES public.mission(id_mission);


--
-- Name: tache fk_tache_mission; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tache
    ADD CONSTRAINT fk_tache_mission FOREIGN KEY (id_mission) REFERENCES public.mission(id_mission);


--
-- PostgreSQL database dump complete
--

alter table "public".details_contrat add salaire double precision;

alter table "public".details_contrat add matricule varchar(500) default 'none';

CREATE or replace view v_avantages as
select ae.id_employe, ae.id_avantage, nom from avantage_employe ae join type_avantage ta
                                                                        on ae.id_avantage = ta.id_avantage;

CREATE or replace view v_missions as
select m.nom, me.id_mission, me.id_fiche_de_poste from mission m join mission_employe me
                                                                      on m.id_mission = me.id_mission;