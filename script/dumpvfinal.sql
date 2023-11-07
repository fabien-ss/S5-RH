--
-- PostgreSQL database dump
--

-- Dumped from database version 12.11
-- Dumped by pg_dump version 12.11

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: annonce; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.annonce (
    id_annonce integer NOT NULL,
    id_service integer,
    debut timestamp without time zone NOT NULL,
    fin timestamp without time zone NOT NULL,
    details character varying(500)
);


ALTER TABLE public.annonce OWNER TO postgres;

--
-- Name: annonce_id_annonce_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.annonce_id_annonce_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.annonce_id_annonce_seq OWNER TO postgres;

--
-- Name: annonce_id_annonce_seq1; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.annonce_id_annonce_seq1
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.annonce_id_annonce_seq1 OWNER TO postgres;

--
-- Name: annonce_id_annonce_seq1; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.annonce_id_annonce_seq1 OWNED BY public.annonce.id_annonce;


--
-- Name: avantage_employe; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.avantage_employe (
    id_employe integer,
    id_avantage integer,
    id integer NOT NULL
);


ALTER TABLE public.avantage_employe OWNER TO postgres;

--
-- Name: avantage_employe_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.avantage_employe_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.avantage_employe_id_seq OWNER TO postgres;

--
-- Name: avantage_employe_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.avantage_employe_id_seq OWNED BY public.avantage_employe.id;


--
-- Name: candidat_cv; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.candidat_cv (
    id_candidat_cv integer NOT NULL,
    id_candidature integer,
    id_diplome integer,
    id_sexe integer,
    id_situation_matrimoniale integer,
    id_poste integer,
    id_experience integer
);


ALTER TABLE public.candidat_cv OWNER TO postgres;

--
-- Name: candidat_cv_id_candidat_cv_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.candidat_cv_id_candidat_cv_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.candidat_cv_id_candidat_cv_seq OWNER TO postgres;

--
-- Name: candidat_cv_id_candidat_cv_seq1; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.candidat_cv_id_candidat_cv_seq1
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.candidat_cv_id_candidat_cv_seq1 OWNER TO postgres;

--
-- Name: candidat_cv_id_candidat_cv_seq1; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.candidat_cv_id_candidat_cv_seq1 OWNED BY public.candidat_cv.id_candidat_cv;


--
-- Name: candidature; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.candidature (
    id_candidature integer NOT NULL,
    id_annonce integer,
    nom character varying(500) NOT NULL,
    prenom character varying(500) NOT NULL,
    date_de_naissane timestamp without time zone NOT NULL,
    contact character varying(500) NOT NULL,
    etat integer DEFAULT 0
);


ALTER TABLE public.candidature OWNER TO postgres;

--
-- Name: candidature_id_candidature_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.candidature_id_candidature_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.candidature_id_candidature_seq OWNER TO postgres;

--
-- Name: candidature_id_candidature_seq1; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.candidature_id_candidature_seq1
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.candidature_id_candidature_seq1 OWNER TO postgres;

--
-- Name: candidature_id_candidature_seq1; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.candidature_id_candidature_seq1 OWNED BY public.candidature.id_candidature;


--
-- Name: coefficient; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.coefficient (
    id_coefficient integer NOT NULL,
    valeur integer,
    text character varying(500)
);


ALTER TABLE public.coefficient OWNER TO postgres;

--
-- Name: coefficient_id_coefficient_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.coefficient_id_coefficient_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.coefficient_id_coefficient_seq OWNER TO postgres;

--
-- Name: coefficient_id_coefficient_seq1; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.coefficient_id_coefficient_seq1
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.coefficient_id_coefficient_seq1 OWNER TO postgres;

--
-- Name: coefficient_id_coefficient_seq1; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.coefficient_id_coefficient_seq1 OWNED BY public.coefficient.id_coefficient;


--
-- Name: conge; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.conge (
    matricule character varying(500),
    date_debut timestamp without time zone,
    date_declaration timestamp without time zone,
    details character varying(500),
    id_type_conge integer,
    date_fin timestamp without time zone,
    validation integer DEFAULT 0,
    id_conge integer NOT NULL
);


ALTER TABLE public.conge OWNER TO postgres;

--
-- Name: conge_duree; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.conge_duree (
    id_conge_duree integer NOT NULL,
    nombre_de_jour integer,
    id_type_conge integer
);


ALTER TABLE public.conge_duree OWNER TO postgres;

--
-- Name: conge_duree_id_conge_duree_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.conge_duree_id_conge_duree_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.conge_duree_id_conge_duree_seq OWNER TO postgres;

--
-- Name: conge_duree_id_conge_duree_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.conge_duree_id_conge_duree_seq OWNED BY public.conge_duree.id_conge_duree;


--
-- Name: conge_id_conge_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.conge_id_conge_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.conge_id_conge_seq OWNER TO postgres;

--
-- Name: conge_id_conge_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.conge_id_conge_seq OWNED BY public.conge.id_conge;


--
-- Name: details_contrat; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.details_contrat (
    id_details_contrat integer NOT NULL,
    date_debut date,
    date_fin date,
    id_type_contrat integer,
    matricule character varying(500) DEFAULT 'none'::character varying,
    id_employe integer,
    is_valide integer DEFAULT 10
);


ALTER TABLE public.details_contrat OWNER TO postgres;

--
-- Name: details_contrat_id_details_contrat_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.details_contrat_id_details_contrat_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.details_contrat_id_details_contrat_seq OWNER TO postgres;

--
-- Name: details_contrat_id_details_contrat_seq1; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.details_contrat_id_details_contrat_seq1
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.details_contrat_id_details_contrat_seq1 OWNER TO postgres;

--
-- Name: details_contrat_id_details_contrat_seq1; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.details_contrat_id_details_contrat_seq1 OWNED BY public.details_contrat.id_details_contrat;


--
-- Name: diplome; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.diplome (
    id_diplome integer NOT NULL,
    details character varying(255) NOT NULL
);


ALTER TABLE public.diplome OWNER TO postgres;

--
-- Name: diplome_id_diplome_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.diplome_id_diplome_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.diplome_id_diplome_seq OWNER TO postgres;

--
-- Name: diplome_id_diplome_seq1; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.diplome_id_diplome_seq1
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.diplome_id_diplome_seq1 OWNER TO postgres;

--
-- Name: diplome_id_diplome_seq1; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.diplome_id_diplome_seq1 OWNED BY public.diplome.id_diplome;


--
-- Name: employe; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.employe (
    id_employe integer NOT NULL,
    id_candidature integer,
    id_superieur integer
);


ALTER TABLE public.employe OWNER TO postgres;

--
-- Name: employe_id_employe_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.employe_id_employe_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.employe_id_employe_seq OWNER TO postgres;

--
-- Name: employe_id_employe_seq1; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.employe_id_employe_seq1
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.employe_id_employe_seq1 OWNER TO postgres;

--
-- Name: employe_id_employe_seq1; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.employe_id_employe_seq1 OWNED BY public.employe.id_employe;


--
-- Name: entreprise; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.entreprise (
    nom character varying(500) NOT NULL,
    date_de_creation timestamp without time zone,
    siege character varying(500),
    numero_fiscal character varying(500),
    logo character varying(500),
    description character varying(500),
    dirigeant integer
);


ALTER TABLE public.entreprise OWNER TO postgres;

--
-- Name: poste; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.poste (
    id_poste integer NOT NULL,
    id_service integer,
    details character varying(500) NOT NULL
);


ALTER TABLE public.poste OWNER TO postgres;

--
-- Name: salaire; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.salaire (
    date_salaire timestamp without time zone,
    salaire double precision,
    id_contrat integer NOT NULL,
    id_type_salaire integer
);


ALTER TABLE public.salaire OWNER TO postgres;

--
-- Name: service; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.service (
    id_service integer NOT NULL,
    nom character varying(200) NOT NULL
);


ALTER TABLE public.service OWNER TO postgres;

--
-- Name: sexe; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sexe (
    id_sexe integer NOT NULL,
    details character varying(255) NOT NULL
);


ALTER TABLE public.sexe OWNER TO postgres;

--
-- Name: type_contrat; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.type_contrat (
    id_type_contrat integer NOT NULL,
    nom character varying(500)
);


ALTER TABLE public.type_contrat OWNER TO postgres;

--
-- Name: type_salaire; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.type_salaire (
    id_type_salaire integer NOT NULL,
    nom character varying(500)
);


ALTER TABLE public.type_salaire OWNER TO postgres;

--
-- Name: v_details_employe; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_details_employe AS
 SELECT c.nom,
    c.prenom,
    c.date_de_naissane AS date_de_naissance,
    c.contact,
    p.details,
    p.id_poste,
    dc.date_debut,
    dc.date_fin,
    dc.matricule,
    tc.nom AS libelle_contrat,
    e.id_employe,
    s.salaire AS renumeration,
    ts.nom AS typesalaire,
    ser.nom AS service,
    dc.*::public.details_contrat AS dc,
    dc.is_valide AS valide,
    cc.id_sexe AS sexe,
    sx.details AS genre,
    date_part('year'::text, age(now(), (c.date_de_naissane)::timestamp with time zone)) AS capacite_exercice,
    date_part('year'::text, age(now(), (dc.date_debut)::timestamp with time zone)) AS anciennete,
    c.id_candidature
   FROM (((((((((public.employe e
     JOIN public.candidature c ON ((e.id_candidature = c.id_candidature)))
     JOIN public.candidat_cv cc ON ((cc.id_candidature = c.id_candidature)))
     JOIN public.poste p ON ((p.id_poste = cc.id_poste)))
     JOIN public.details_contrat dc ON ((e.id_employe = dc.id_employe)))
     JOIN public.type_contrat tc ON ((dc.id_type_contrat = tc.id_type_contrat)))
     JOIN public.salaire s ON ((s.id_contrat = dc.id_details_contrat)))
     JOIN public.type_salaire ts ON ((ts.id_type_salaire = s.id_type_salaire)))
     JOIN public.service ser ON ((p.id_service = ser.id_service)))
     JOIN public.sexe sx ON ((sx.id_sexe = cc.id_sexe)))
  WHERE (dc.is_valide = 0);


ALTER TABLE public.v_details_employe OWNER TO postgres;

--
-- Name: etat_de_paie; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.etat_de_paie AS
 SELECT vde.nom,
    vde.prenom,
    vde.date_de_naissance,
    vde.contact,
    vde.details,
    vde.id_poste,
    vde.date_debut,
    vde.date_fin,
    vde.matricule,
    vde.libelle_contrat,
    vde.id_employe,
    vde.renumeration,
    vde.typesalaire,
    vde.service,
    vde.dc,
    vde.valide,
    vde.sexe,
    vde.genre,
    vde.capacite_exercice,
    vde.anciennete,
    vde.id_candidature,
    p.details AS fonction
   FROM (public.v_details_employe vde
     JOIN public.poste p ON ((p.id_poste = vde.id_poste)));


ALTER TABLE public.etat_de_paie OWNER TO postgres;

--
-- Name: experience; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.experience (
    id_experience integer NOT NULL,
    details character varying(255) NOT NULL
);


ALTER TABLE public.experience OWNER TO postgres;

--
-- Name: experience_id_experience_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.experience_id_experience_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.experience_id_experience_seq OWNER TO postgres;

--
-- Name: experience_id_experience_seq1; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.experience_id_experience_seq1
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.experience_id_experience_seq1 OWNER TO postgres;

--
-- Name: experience_id_experience_seq1; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.experience_id_experience_seq1 OWNED BY public.experience.id_experience;


--
-- Name: horaire; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.horaire (
    id integer NOT NULL,
    id_contrat integer,
    entree character varying,
    sortie character varying,
    id_jour integer
);


ALTER TABLE public.horaire OWNER TO postgres;

--
-- Name: horaire_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.horaire_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.horaire_id_seq OWNER TO postgres;

--
-- Name: horaire_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.horaire_id_seq OWNED BY public.horaire.id;


--
-- Name: jour; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.jour (
    id_jour integer NOT NULL,
    jour character varying
);


ALTER TABLE public.jour OWNER TO postgres;

--
-- Name: jour_id_jour_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.jour_id_jour_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.jour_id_jour_seq OWNER TO postgres;

--
-- Name: jour_id_jour_seq1; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.jour_id_jour_seq1
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.jour_id_jour_seq1 OWNER TO postgres;

--
-- Name: jour_id_jour_seq1; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.jour_id_jour_seq1 OWNED BY public.jour.id_jour;


--
-- Name: mission; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.mission (
    id_mission integer NOT NULL,
    nom character varying(500),
    id_poste integer
);


ALTER TABLE public.mission OWNER TO postgres;

--
-- Name: mission_id_mission_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.mission_id_mission_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.mission_id_mission_seq OWNER TO postgres;

--
-- Name: mission_id_mission_seq1; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.mission_id_mission_seq1
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.mission_id_mission_seq1 OWNER TO postgres;

--
-- Name: mission_id_mission_seq1; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.mission_id_mission_seq1 OWNED BY public.mission.id_mission;


--
-- Name: note; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.note (
    id_candidature integer NOT NULL,
    note_cv double precision,
    note_question double precision
);


ALTER TABLE public.note OWNER TO postgres;

--
-- Name: note_id_candidature_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.note_id_candidature_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.note_id_candidature_seq OWNER TO postgres;

--
-- Name: note_id_candidature_seq1; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.note_id_candidature_seq1
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.note_id_candidature_seq1 OWNER TO postgres;

--
-- Name: note_id_candidature_seq1; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.note_id_candidature_seq1 OWNED BY public.note.id_candidature;


--
-- Name: poste_id_poste_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.poste_id_poste_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.poste_id_poste_seq OWNER TO postgres;

--
-- Name: poste_id_poste_seq1; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.poste_id_poste_seq1
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.poste_id_poste_seq1 OWNER TO postgres;

--
-- Name: poste_id_poste_seq1; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.poste_id_poste_seq1 OWNED BY public.poste.id_poste;


--
-- Name: qualification; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.qualification (
    id_qualification integer NOT NULL,
    id_annonce integer,
    diplome character varying(500) NOT NULL,
    experience character varying(500) NOT NULL,
    sexe character varying(500) NOT NULL,
    situation_matrimoniale character varying(500) NOT NULL
);


ALTER TABLE public.qualification OWNER TO postgres;

--
-- Name: qualification_id_qualification_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.qualification_id_qualification_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.qualification_id_qualification_seq OWNER TO postgres;

--
-- Name: qualification_id_qualification_seq1; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.qualification_id_qualification_seq1
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.qualification_id_qualification_seq1 OWNER TO postgres;

--
-- Name: qualification_id_qualification_seq1; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.qualification_id_qualification_seq1 OWNED BY public.qualification.id_qualification;


--
-- Name: question; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.question (
    id_question integer NOT NULL,
    question character varying(255) NOT NULL,
    id_annonce integer,
    point integer
);


ALTER TABLE public.question OWNER TO postgres;

--
-- Name: question_id_question_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.question_id_question_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.question_id_question_seq OWNER TO postgres;

--
-- Name: question_id_question_seq1; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.question_id_question_seq1
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.question_id_question_seq1 OWNER TO postgres;

--
-- Name: question_id_question_seq1; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.question_id_question_seq1 OWNED BY public.question.id_question;


--
-- Name: reponse; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.reponse (
    id_question integer,
    id_reponse integer NOT NULL,
    reponse character varying(255) NOT NULL,
    verite integer NOT NULL
);


ALTER TABLE public.reponse OWNER TO postgres;

--
-- Name: reponse_id_reponse_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.reponse_id_reponse_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.reponse_id_reponse_seq OWNER TO postgres;

--
-- Name: reponse_id_reponse_seq1; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.reponse_id_reponse_seq1
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.reponse_id_reponse_seq1 OWNER TO postgres;

--
-- Name: reponse_id_reponse_seq1; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.reponse_id_reponse_seq1 OWNED BY public.reponse.id_reponse;


--
-- Name: service_id_service_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.service_id_service_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.service_id_service_seq OWNER TO postgres;

--
-- Name: service_id_service_seq1; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.service_id_service_seq1
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.service_id_service_seq1 OWNER TO postgres;

--
-- Name: service_id_service_seq1; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.service_id_service_seq1 OWNED BY public.service.id_service;


--
-- Name: sexe_id_sexe_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.sexe_id_sexe_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.sexe_id_sexe_seq OWNER TO postgres;

--
-- Name: sexe_id_sexe_seq1; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.sexe_id_sexe_seq1
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.sexe_id_sexe_seq1 OWNER TO postgres;

--
-- Name: sexe_id_sexe_seq1; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.sexe_id_sexe_seq1 OWNED BY public.sexe.id_sexe;


--
-- Name: situation_matrimoniale; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.situation_matrimoniale (
    id_situation_matrimoniale integer NOT NULL,
    details character varying(255) NOT NULL
);


ALTER TABLE public.situation_matrimoniale OWNER TO postgres;

--
-- Name: situation_matrimoniale_id_situation_matrimoniale_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.situation_matrimoniale_id_situation_matrimoniale_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.situation_matrimoniale_id_situation_matrimoniale_seq OWNER TO postgres;

--
-- Name: situation_matrimoniale_id_situation_matrimoniale_seq1; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.situation_matrimoniale_id_situation_matrimoniale_seq1
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.situation_matrimoniale_id_situation_matrimoniale_seq1 OWNER TO postgres;

--
-- Name: situation_matrimoniale_id_situation_matrimoniale_seq1; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.situation_matrimoniale_id_situation_matrimoniale_seq1 OWNED BY public.situation_matrimoniale.id_situation_matrimoniale;


--
-- Name: tache; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tache (
    id_tache integer NOT NULL,
    nom character varying,
    id_mission integer
);


ALTER TABLE public.tache OWNER TO postgres;

--
-- Name: tache_id_tache_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.tache_id_tache_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.tache_id_tache_seq OWNER TO postgres;

--
-- Name: tache_id_tache_seq1; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.tache_id_tache_seq1
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.tache_id_tache_seq1 OWNER TO postgres;

--
-- Name: tache_id_tache_seq1; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.tache_id_tache_seq1 OWNED BY public.tache.id_tache;


--
-- Name: type_avantage; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.type_avantage (
    id_avantage integer NOT NULL,
    nom character varying(500)
);


ALTER TABLE public.type_avantage OWNER TO postgres;

--
-- Name: type_avantage_id_avantage_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.type_avantage_id_avantage_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.type_avantage_id_avantage_seq OWNER TO postgres;

--
-- Name: type_avantage_id_avantage_seq1; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.type_avantage_id_avantage_seq1
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.type_avantage_id_avantage_seq1 OWNER TO postgres;

--
-- Name: type_avantage_id_avantage_seq1; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.type_avantage_id_avantage_seq1 OWNED BY public.type_avantage.id_avantage;


--
-- Name: type_conge; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.type_conge (
    id_type_conge integer NOT NULL,
    libelle character varying(500)
);


ALTER TABLE public.type_conge OWNER TO postgres;

--
-- Name: type_conge_id_type_conge_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.type_conge_id_type_conge_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.type_conge_id_type_conge_seq OWNER TO postgres;

--
-- Name: type_conge_id_type_conge_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.type_conge_id_type_conge_seq OWNED BY public.type_conge.id_type_conge;


--
-- Name: type_contrat_id_type_contrat_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.type_contrat_id_type_contrat_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.type_contrat_id_type_contrat_seq OWNER TO postgres;

--
-- Name: type_contrat_id_type_contrat_seq1; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.type_contrat_id_type_contrat_seq1
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.type_contrat_id_type_contrat_seq1 OWNER TO postgres;

--
-- Name: type_contrat_id_type_contrat_seq1; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.type_contrat_id_type_contrat_seq1 OWNED BY public.type_contrat.id_type_contrat;


--
-- Name: type_salaire_id_type_salaire_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.type_salaire_id_type_salaire_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.type_salaire_id_type_salaire_seq OWNER TO postgres;

--
-- Name: type_salaire_id_type_salaire_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.type_salaire_id_type_salaire_seq OWNED BY public.type_salaire.id_type_salaire;


--
-- Name: v_classement; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_classement AS
 SELECT (n.note_question + n.note_cv) AS notec,
    c.nom,
    c.id_annonce,
    c.id_candidature
   FROM (public.note n
     JOIN public.candidature c ON ((n.id_candidature = c.id_candidature)))
  ORDER BY (n.note_question + n.note_cv) DESC;


ALTER TABLE public.v_classement OWNER TO postgres;

--
-- Name: v_details_contrat; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_details_contrat AS
 SELECT dc.id_details_contrat,
    dc.date_debut,
    dc.date_fin,
    tc.nom
   FROM (public.details_contrat dc
     JOIN public.type_contrat tc ON ((dc.id_type_contrat = tc.id_type_contrat)));


ALTER TABLE public.v_details_contrat OWNER TO postgres;

--
-- Name: v_employe; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_employe AS
 SELECT e.id_candidature,
    e.id_superieur,
    c.nom,
    c.prenom,
    p.details,
    e.id_employe,
    c.etat
   FROM (((public.employe e
     JOIN public.candidature c ON ((e.id_candidature = c.id_candidature)))
     JOIN public.candidat_cv cc ON ((cc.id_candidature = c.id_candidature)))
     JOIN public.poste p ON ((cc.id_poste = p.id_poste)));


ALTER TABLE public.v_employe OWNER TO postgres;

--
-- Name: v_employe_par_service; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_employe_par_service AS
 SELECT s.id_service,
    vde.id_employe,
    vde.nom,
    vde.prenom
   FROM ((public.service s
     JOIN public.poste p ON ((s.id_service = p.id_service)))
     JOIN public.v_details_employe vde ON ((vde.id_poste = p.id_poste)));


ALTER TABLE public.v_employe_par_service OWNER TO postgres;

--
-- Name: v_horaire; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_horaire AS
 SELECT h.id_contrat,
    h.entree,
    h.sortie,
    h.id_jour,
    j.jour,
    dc.date_debut,
    dc.is_valide AS valide
   FROM ((public.horaire h
     JOIN public.jour j ON ((h.id_jour = j.id_jour)))
     JOIN public.details_contrat dc ON ((h.id_contrat = dc.id_details_contrat)))
  WHERE (dc.is_valide = 0);


ALTER TABLE public.v_horaire OWNER TO postgres;

--
-- Name: v_horraire; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_horraire AS
 SELECT h.id_contrat,
    h.entree,
    h.sortie,
    j.jour,
    e.id_employe
   FROM (((public.jour j
     JOIN public.horaire h ON ((j.id_jour = h.id_jour)))
     JOIN public.details_contrat dc ON ((dc.id_details_contrat = h.id_contrat)))
     JOIN public.employe e ON ((e.id_employe = dc.id_employe)))
  WHERE (dc.is_valide = 10);


ALTER TABLE public.v_horraire OWNER TO postgres;

--
-- Name: v_liste_personne_conge; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_liste_personne_conge AS
 SELECT cd.nom,
    cd.prenom,
    c.matricule,
    c.date_debut,
    c.date_declaration,
    c.id_type_conge,
    tc.libelle
   FROM ((((public.conge c
     JOIN public.details_contrat dc ON (((c.matricule)::text = (dc.matricule)::text)))
     JOIN public.employe e ON ((e.id_employe = dc.id_employe)))
     JOIN public.candidature cd ON ((cd.id_candidature = e.id_candidature)))
     JOIN public.type_conge tc ON ((tc.id_type_conge = c.id_type_conge)))
  WHERE ((c.date_fin IS NULL) AND (c.validation <> 0));


ALTER TABLE public.v_liste_personne_conge OWNER TO postgres;

--
-- Name: v_question_reponse; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_question_reponse AS
 SELECT q.id_question,
    q.question,
    q.id_annonce,
    r.id_reponse,
    r.reponse,
    r.verite
   FROM (public.question q
     JOIN public.reponse r ON ((q.id_question = r.id_question)));


ALTER TABLE public.v_question_reponse OWNER TO postgres;

--
-- Name: annonce id_annonce; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.annonce ALTER COLUMN id_annonce SET DEFAULT nextval('public.annonce_id_annonce_seq1'::regclass);


--
-- Name: avantage_employe id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.avantage_employe ALTER COLUMN id SET DEFAULT nextval('public.avantage_employe_id_seq'::regclass);


--
-- Name: candidat_cv id_candidat_cv; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.candidat_cv ALTER COLUMN id_candidat_cv SET DEFAULT nextval('public.candidat_cv_id_candidat_cv_seq1'::regclass);


--
-- Name: candidature id_candidature; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.candidature ALTER COLUMN id_candidature SET DEFAULT nextval('public.candidature_id_candidature_seq1'::regclass);


--
-- Name: coefficient id_coefficient; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.coefficient ALTER COLUMN id_coefficient SET DEFAULT nextval('public.coefficient_id_coefficient_seq1'::regclass);


--
-- Name: conge id_conge; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.conge ALTER COLUMN id_conge SET DEFAULT nextval('public.conge_id_conge_seq'::regclass);


--
-- Name: conge_duree id_conge_duree; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.conge_duree ALTER COLUMN id_conge_duree SET DEFAULT nextval('public.conge_duree_id_conge_duree_seq'::regclass);


--
-- Name: details_contrat id_details_contrat; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.details_contrat ALTER COLUMN id_details_contrat SET DEFAULT nextval('public.details_contrat_id_details_contrat_seq1'::regclass);


--
-- Name: diplome id_diplome; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.diplome ALTER COLUMN id_diplome SET DEFAULT nextval('public.diplome_id_diplome_seq1'::regclass);


--
-- Name: employe id_employe; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employe ALTER COLUMN id_employe SET DEFAULT nextval('public.employe_id_employe_seq1'::regclass);


--
-- Name: experience id_experience; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.experience ALTER COLUMN id_experience SET DEFAULT nextval('public.experience_id_experience_seq1'::regclass);


--
-- Name: horaire id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.horaire ALTER COLUMN id SET DEFAULT nextval('public.horaire_id_seq'::regclass);


--
-- Name: jour id_jour; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.jour ALTER COLUMN id_jour SET DEFAULT nextval('public.jour_id_jour_seq1'::regclass);


--
-- Name: mission id_mission; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.mission ALTER COLUMN id_mission SET DEFAULT nextval('public.mission_id_mission_seq1'::regclass);


--
-- Name: note id_candidature; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.note ALTER COLUMN id_candidature SET DEFAULT nextval('public.note_id_candidature_seq1'::regclass);


--
-- Name: poste id_poste; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.poste ALTER COLUMN id_poste SET DEFAULT nextval('public.poste_id_poste_seq1'::regclass);


--
-- Name: qualification id_qualification; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.qualification ALTER COLUMN id_qualification SET DEFAULT nextval('public.qualification_id_qualification_seq1'::regclass);


--
-- Name: question id_question; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.question ALTER COLUMN id_question SET DEFAULT nextval('public.question_id_question_seq1'::regclass);


--
-- Name: reponse id_reponse; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.reponse ALTER COLUMN id_reponse SET DEFAULT nextval('public.reponse_id_reponse_seq1'::regclass);


--
-- Name: service id_service; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.service ALTER COLUMN id_service SET DEFAULT nextval('public.service_id_service_seq1'::regclass);


--
-- Name: sexe id_sexe; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sexe ALTER COLUMN id_sexe SET DEFAULT nextval('public.sexe_id_sexe_seq1'::regclass);


--
-- Name: situation_matrimoniale id_situation_matrimoniale; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.situation_matrimoniale ALTER COLUMN id_situation_matrimoniale SET DEFAULT nextval('public.situation_matrimoniale_id_situation_matrimoniale_seq1'::regclass);


--
-- Name: tache id_tache; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tache ALTER COLUMN id_tache SET DEFAULT nextval('public.tache_id_tache_seq1'::regclass);


--
-- Name: type_avantage id_avantage; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.type_avantage ALTER COLUMN id_avantage SET DEFAULT nextval('public.type_avantage_id_avantage_seq1'::regclass);


--
-- Name: type_conge id_type_conge; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.type_conge ALTER COLUMN id_type_conge SET DEFAULT nextval('public.type_conge_id_type_conge_seq'::regclass);


--
-- Name: type_contrat id_type_contrat; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.type_contrat ALTER COLUMN id_type_contrat SET DEFAULT nextval('public.type_contrat_id_type_contrat_seq1'::regclass);


--
-- Name: type_salaire id_type_salaire; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.type_salaire ALTER COLUMN id_type_salaire SET DEFAULT nextval('public.type_salaire_id_type_salaire_seq'::regclass);


--
-- Data for Name: annonce; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.annonce (id_annonce, id_service, debut, fin, details) FROM stdin;
7	1	2023-10-20 23:13:00	2023-10-20 23:13:00	Professeur de Physique
6	1	2023-10-20 22:54:00	2023-10-20 22:54:00	Chef de cuisine
3	3	2023-10-10 00:00:00	2023-10-25 00:00:00	Full stack Java Senior Developper
4	1	2023-10-20 20:43:00	2023-10-20 20:43:00	Coursier
5	2	2023-10-20 22:50:00	2023-10-20 22:50:00	Gardien
1	1	2023-10-01 00:00:00	2023-10-15 00:00:00	Web Designer
2	1	2023-09-15 00:00:00	2023-10-30 00:00:00	Comptable
\.


--
-- Data for Name: avantage_employe; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.avantage_employe (id_employe, id_avantage, id) FROM stdin;
1	1	1
2	1	2
3	1	3
4	1	4
4	2	5
4	3	6
4	1	7
4	1	8
5	1	9
5	1	10
6	1	11
6	1	12
6	2	13
7	1	14
8	3	15
8	3	16
8	1	17
7	3	18
9	3	19
7	3	20
7	1	21
9	3	22
10	3	23
11	3	24
11	1	25
12	3	26
12	3	27
13	3	28
13	1	29
13	2	30
13	3	31
13	1	32
\.


--
-- Data for Name: candidat_cv; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.candidat_cv (id_candidat_cv, id_candidature, id_diplome, id_sexe, id_situation_matrimoniale, id_poste, id_experience) FROM stdin;
1	1	1	1	1	1	3
2	2	2	2	2	3	1
3	3	3	1	1	4	1
4	5	1	1	1	2	1
5	6	1	1	1	2	1
6	7	1	1	1	4	1
7	8	1	1	2	2	1
8	9	1	1	3	1	1
9	10	1	1	3	4	1
10	11	1	1	3	1	1
11	12	1	1	3	2	1
12	13	1	1	3	1	1
13	14	1	1	3	3	1
\.


--
-- Data for Name: candidature; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.candidature (id_candidature, id_annonce, nom, prenom, date_de_naissane, contact, etat) FROM stdin;
1	1	Doe	John	1999-01-12 22:22:22	john.doe@example.com	30
2	2	Smith	Alice	1999-01-12 22:22:22	alice.smith@example.com	30
3	3	Brown	David	1999-01-12 22:22:22	david.brown@example.com	30
5	7	OKOK	D	1999-01-12 22:22:22	DQS	30
6	1	ppp	p	1999-01-12 22:22:22	sq	30
4	7	Fabi	a	1999-01-12 22:22:22	d	30
8	6	Rakotomanana	Andriniaina Fabien	1999-01-12 22:22:22	033 12 213 12	30
7	3	TOTO	T	1999-01-12 22:22:22	213131231	30
9	7	d	d	1999-01-12 22:22:22	d	30
10	3	d	s	1999-01-12 22:22:22	s	10
11	6	Fabien	f	1988-12-31 22:59:59.999	43242341	10
12	6	Fabien	fabien	1999-12-31 22:59:59.999	xx	0
13	6	Rakoto	Julien	1999-12-31 22:59:59.999	0342154522	30
14	2	Andrianaivo	Lala	2000-11-04 00:00:00	0332568525	30
\.


--
-- Data for Name: coefficient; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.coefficient (id_coefficient, valeur, text) FROM stdin;
2	3	Acceptable
1	5	Recommended
3	1	Average
\.


--
-- Data for Name: conge; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.conge (matricule, date_debut, date_declaration, details, id_type_conge, date_fin, validation, id_conge) FROM stdin;
FA0000012	2023-11-04 15:34:00	2023-11-04 15:34:00	Je n'en peu plus	4	2023-11-04 16:48:19.342574	10	15
\.


--
-- Data for Name: conge_duree; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.conge_duree (id_conge_duree, nombre_de_jour, id_type_conge) FROM stdin;
\.


--
-- Data for Name: details_contrat; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.details_contrat (id_details_contrat, date_debut, date_fin, id_type_contrat, matricule, id_employe, is_valide) FROM stdin;
20	2023-11-04	2024-03-04	3	None	12	10
22	2023-11-04	2024-02-04	3	None	13	10
23	2000-12-02	2024-11-02	2	FA0000013	13	0
21	2019-11-04	2024-05-04	2	FA0000012	12	0
18	2023-11-04	2024-04-04	3	FA0000010	10	0
13	2023-10-22	2025-12-22	2	FA0000008	8	0
2	2023-10-14	2023-10-14	1		2	10
16	2023-11-04	2024-08-04	2	FA0000007	7	0
7	2023-10-21	2025-03-21	1		5	10
5	2023-10-20	2027-01-20	1		4	10
4	2023-10-20	2025-08-20	1		4	10
10	2023-10-21	2024-02-21	2	FA0000006	6	0
15	2023-10-23	2024-09-23	3		9	10
1	2023-10-14	2023-10-14	1		1	10
14	2023-10-23	2024-02-23	3		7	10
11	2023-10-21	2024-11-21	3		7	10
3	2023-10-14	2023-10-14	2		3	10
9	2021-10-21	2026-11-21	1		6	10
6	2023-10-20	2024-09-20	2	FA0000004	4	0
12	2023-10-22	2023-12-22	3		8	10
8	2023-10-20	2024-11-20	2	FA0000005	5	0
19	2023-11-04	2024-03-04	3	FA0000011	11	0
17	2023-11-04	2024-01-04	2	FA0000009	9	0
\.


--
-- Data for Name: diplome; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.diplome (id_diplome, details) FROM stdin;
1	Doctorat
2	Master
3	Licence
4	Baccalaureat
\.


--
-- Data for Name: employe; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.employe (id_employe, id_candidature, id_superieur) FROM stdin;
8	8	\N
11	11	8
5	5	8
1	1	8
7	7	8
9	9	8
10	10	8
4	4	8
6	6	8
3	3	8
2	2	8
12	13	8
13	14	8
\.


--
-- Data for Name: entreprise; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.entreprise (nom, date_de_creation, siege, numero_fiscal, logo, description, dirigeant) FROM stdin;
MAHAKO	2023-10-14 07:01:15.258819	ANTANANARIVO Ambatondrazaka	EAZFGFD9423495043483243204884923423402238444	entrepriselogo.png	Entreprise livraison	\N
\.


--
-- Data for Name: experience; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.experience (id_experience, details) FROM stdin;
1	+5 ans
2	+3 ans
3	+2 ans
\.


--
-- Data for Name: horaire; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.horaire (id, id_contrat, entree, sortie, id_jour) FROM stdin;
1	1	12:32	16:30	1
2	1	12:32	16:30	2
3	1	12:32	16:30	3
4	1	12:32	16:30	4
5	2	12:32	16:30	1
6	2	12:32	16:30	2
7	2	12:32	16:30	5
8	3	12:32	16:30	5
9	3	12:32	16:30	4
10	4	23:33	23:33	1
11	4	23:33	23:33	2
12	4	23:33	23:33	3
13	4	23:33	23:33	4
14	4	23:33	23:33	5
15	4	23:33	23:33	6
16	5	23:42	05:42	1
17	5	23:42	05:42	2
18	5	23:42	05:42	3
19	5	23:42	05:42	4
20	5	23:42	05:42	5
21	5	23:42	05:42	6
22	6	23:43	05:43	1
23	6	23:43	05:43	2
24	6	23:43	05:43	3
25	6	23:43	05:43	4
26	6	23:43	05:43	5
27	6	23:43	05:43	6
28	7	03:29	05:29	1
29	7	03:29	05:29	2
30	7	03:29	05:29	3
31	7	03:29	05:29	4
32	7	03:29	05:29	5
33	7	03:29	05:29	6
34	8	03:30	09:30	1
35	8	03:30	09:30	2
36	8	03:30	09:30	3
37	8	03:30	09:30	4
38	8	03:30	09:30	5
39	8	03:30	09:30	6
40	9	03:34	09:34	1
41	9	03:34	09:34	2
42	9	03:34	09:34	3
43	9	03:34	09:34	4
44	9	03:34	09:34	5
45	9	03:34	09:34	6
46	10	04:05	08:05	1
47	10	04:05	08:05	2
48	10	04:05	08:05	3
49	10	04:05	08:05	4
50	10	04:05	08:05	5
51	10	04:05	08:05	6
52	11	04:14	10:14	1
53	11	04:14	10:14	2
54	11	04:14	10:14	3
55	11	04:14	10:14	4
56	11	04:14	10:14	5
57	11	04:14	10:14	6
58	12	13:25	19:25	1
59	12	13:25	19:25	2
60	12	13:25	19:25	3
61	12	13:25	19:25	4
62	12	13:25	19:25	5
63	12	13:25	19:25	6
64	13	13:26	19:26	1
65	13	13:26	19:26	2
66	13	13:26	19:26	3
67	13	13:26	19:26	4
68	13	13:26	19:26	5
69	13	13:26	19:26	6
70	14	08:54	13:54	1
71	14	08:54	13:54	2
72	14	08:54	13:54	3
73	14	08:54	13:54	4
74	14	08:54	13:54	5
75	14	08:54	13:54	6
76	15	08:58	14:58	1
77	15	08:58	14:58	2
78	15	08:58	14:58	3
79	15	08:58	14:58	4
80	15	08:58	14:58	5
81	15	08:58	14:58	6
82	16	07:04	13:04	1
83	16	07:04	13:04	2
84	16	07:04	13:04	3
85	16	07:04	13:04	4
86	16	07:04	13:04	5
87	16	07:04	13:04	6
88	17	07:05	13:05	1
89	17	07:05	13:05	2
90	17	07:05	13:05	3
91	17	07:05	13:05	4
92	17	07:05	13:05	5
93	17	07:05	13:05	6
94	18	07:35	13:35	1
95	18	07:35	13:35	2
96	18	07:35	13:35	3
97	18	07:35	13:35	4
98	18	07:35	13:35	5
99	18	07:35	13:35	6
100	19	07:46	13:46	1
101	19	07:46	13:46	2
102	19	07:46	13:46	3
103	19	07:46	13:46	4
104	19	07:46	13:46	5
105	19	07:46	13:46	6
106	20	08:32	14:32	1
107	20	08:32	14:32	2
108	20	08:32	14:32	3
109	20	08:32	14:32	4
110	20	08:32	14:32	5
111	21	08:32	14:32	1
112	21	08:32	14:32	2
113	21	08:32	14:32	3
114	21	08:32	14:32	4
115	21	08:32	14:32	5
116	21	08:32	14:32	6
117	22	08:55	14:56	1
118	22	08:55	14:56	2
119	22	08:55	14:56	3
120	22	08:55	14:56	4
121	22	08:55	14:56	5
122	22	08:55	14:56	6
123	23	08:59	14:59	1
124	23	08:59	14:59	2
125	23	08:59	14:59	4
126	23	08:59	14:59	5
\.


--
-- Data for Name: jour; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.jour (id_jour, jour) FROM stdin;
1	Lundi
2	Mardi
3	Mercredi
4	Jeudi
5	Vendredi
6	Samedi
\.


--
-- Data for Name: mission; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.mission (id_mission, nom, id_poste) FROM stdin;
1	Conception Objet	1
2	Designer	2
3	Data analyst	3
4	Garder le code propre	4
\.


--
-- Data for Name: note; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.note (id_candidature, note_cv, note_question) FROM stdin;
1	\N	\N
2	\N	\N
3	\N	\N
4	14	0
5	14	5
6	10	0
7	6	0
8	20	0
9	12	0
10	7	0
11	20	0
12	20	0
13	20	0
14	5	1
\.


--
-- Data for Name: poste; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.poste (id_poste, id_service, details) FROM stdin;
2	1	Gestionnaire de Paie
3	2	Comptable
4	3	Developpeur Web Junior
1	1	Responsable communication
\.


--
-- Data for Name: qualification; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.qualification (id_qualification, id_annonce, diplome, experience, sexe, situation_matrimoniale) FROM stdin;
1	1	1=4;2=3;3=1;4=0	1=3;2=1;3=1	1=2;2=1	1=1;2=1;3=2
2	2	1=1;2=1;3=2;4=4	1=1;2=1;3=3	1=2;2=1	1=1;2=2;3=1
3	3	1=1;2=3;3=1;4=3	1=2;2=2;3=2	1=2;2=1	1=1;2=2;3=2
4	4	1=1;2=1;3=1;4=1;	1=1;2=1;3=1;	1=1;2=1;	1=1;2=1;3=1;4=1;5=1;6=1;
5	5	1=5;2=5;3=5;4=5;	1=5;2=5;3=5;	1=5;2=5;	1=5;2=5;3=5;4=5;5=5;6=5;
6	6	1=5;2=5;3=5;4=5;	1=5;2=5;3=5;	1=5;2=5;	1=5;2=5;3=5;4=5;5=5;6=5;
7	7	1=5;2=1;3=1;4=1;	1=3;2=5;3=5;	1=1;2=1;	1=5;2=5;3=3;4=5;5=5;6=5;
\.


--
-- Data for Name: question; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.question (id_question, question, id_annonce, point) FROM stdin;
4	Quelle est la capitale de la Russier	5	0
5	Qui a decouvert l'amerique?	5	0
6	Fabien	7	5
7	Mamisoa	7	5
8	Vizaka?	7	5
2	Diplome de base	2	1
1	Qui a gagné les jeux olympiques	1	2
3	Key of succes?	3	3
\.


--
-- Data for Name: reponse; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.reponse (id_question, id_reponse, reponse, verite) FROM stdin;
2	3	Licence en Gestion des Ressources Humaines	1
3	5	3 ans	1
3	6	1 an	0
1	1	Imalaya	1
1	2	Everest	0
4	7	Maldive	0
4	8	Esoagne	0
4	9	Aucun	1
5	10	Christophe Colombe	1
5	11	Jean jacque goldman	0
6	12	Gentil	0
6	13	Méchant	1
7	14	Gentil	1
7	15	Makaray loha	0
8	16	Oui	1
8	17	Fuck eh!	0
2	4	Baccalaureat en Informatique	0
\.


--
-- Data for Name: salaire; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.salaire (date_salaire, salaire, id_contrat, id_type_salaire) FROM stdin;
2023-10-14 07:01:15.16434	1231	1	1
2023-10-14 07:01:15.16434	42431	2	2
2023-10-14 07:01:15.16434	4324	3	2
2023-10-20 23:35:11.656634	5000000	4	1
2023-10-20 23:42:29.352626	7	5	1
2023-10-20 23:43:30.617617	321351	6	1
2023-10-21 03:29:36.675346	500000	7	1
2023-10-21 03:30:07.003072	500000	8	1
2023-10-21 03:34:13.631283	31231	9	1
2023-10-21 04:05:14.741547	400000	10	1
2023-10-21 04:14:14.048995	500000	11	1
2023-10-22 13:25:56.716236	400000	12	1
2023-10-22 13:26:34.575714	500000	13	1
2023-10-23 08:54:53.329325	54154545	14	1
2023-10-23 08:58:17.078658	313135213	15	1
2023-11-04 07:04:56.560388	200000	16	1
2023-11-04 07:06:05.513675	2000000	17	1
2023-11-04 07:36:02.854992	700000	18	1
2023-11-04 07:46:42.603991	500000	19	1
2023-11-04 08:32:08.162186	500000	20	1
2023-11-04 08:32:36.897581	700000	21	1
2023-11-04 08:56:06.056868	600000	22	1
2023-11-04 08:59:13.594011	1000000	23	1
\.


--
-- Data for Name: service; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.service (id_service, nom) FROM stdin;
1	Service RH
2	Service Finances
3	Service Informatique
\.


--
-- Data for Name: sexe; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.sexe (id_sexe, details) FROM stdin;
1	Homme
2	Femme
\.


--
-- Data for Name: situation_matrimoniale; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.situation_matrimoniale (id_situation_matrimoniale, details) FROM stdin;
3	Divorce(e)
2	Marie(e)
1	Celibataire
4	Celibataire
6	Divorce(e)
5	Marie(e)
\.


--
-- Data for Name: tache; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tache (id_tache, nom, id_mission) FROM stdin;
1	Ordinateur	1
3	Acheter du pain	2
4	Maintenir les systemes propres	2
6	Ordinateur maintenance	4
2	Netoyer la salle	1
5	Etre en bonne sante	3
\.


--
-- Data for Name: type_avantage; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.type_avantage (id_avantage, nom) FROM stdin;
3	Assistant(e)
1	Vehicule
2	Phone
\.


--
-- Data for Name: type_conge; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.type_conge (id_type_conge, libelle) FROM stdin;
4	Autre
3	Partenite
1	Conge mensuel
2	Maternite
\.


--
-- Data for Name: type_contrat; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.type_contrat (id_type_contrat, nom) FROM stdin;
3	CE
1	CDI
2	CDD
\.


--
-- Data for Name: type_salaire; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.type_salaire (id_type_salaire, nom) FROM stdin;
1	Brute
2	Net
\.


--
-- Name: annonce_id_annonce_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.annonce_id_annonce_seq', 1, false);


--
-- Name: annonce_id_annonce_seq1; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.annonce_id_annonce_seq1', 7, true);


--
-- Name: avantage_employe_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.avantage_employe_id_seq', 32, true);


--
-- Name: candidat_cv_id_candidat_cv_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.candidat_cv_id_candidat_cv_seq', 1, false);


--
-- Name: candidat_cv_id_candidat_cv_seq1; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.candidat_cv_id_candidat_cv_seq1', 13, true);


--
-- Name: candidature_id_candidature_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.candidature_id_candidature_seq', 1, false);


--
-- Name: candidature_id_candidature_seq1; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.candidature_id_candidature_seq1', 14, true);


--
-- Name: coefficient_id_coefficient_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.coefficient_id_coefficient_seq', 1, false);


--
-- Name: coefficient_id_coefficient_seq1; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.coefficient_id_coefficient_seq1', 3, true);


--
-- Name: conge_duree_id_conge_duree_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.conge_duree_id_conge_duree_seq', 1, false);


--
-- Name: conge_id_conge_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.conge_id_conge_seq', 15, true);


--
-- Name: details_contrat_id_details_contrat_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.details_contrat_id_details_contrat_seq', 1, false);


--
-- Name: details_contrat_id_details_contrat_seq1; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.details_contrat_id_details_contrat_seq1', 23, true);


--
-- Name: diplome_id_diplome_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.diplome_id_diplome_seq', 1, false);


--
-- Name: diplome_id_diplome_seq1; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.diplome_id_diplome_seq1', 4, true);


--
-- Name: employe_id_employe_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.employe_id_employe_seq', 1, false);


--
-- Name: employe_id_employe_seq1; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.employe_id_employe_seq1', 13, true);


--
-- Name: experience_id_experience_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.experience_id_experience_seq', 1, false);


--
-- Name: experience_id_experience_seq1; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.experience_id_experience_seq1', 3, true);


--
-- Name: horaire_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.horaire_id_seq', 126, true);


--
-- Name: jour_id_jour_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.jour_id_jour_seq', 1, false);


--
-- Name: jour_id_jour_seq1; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.jour_id_jour_seq1', 6, true);


--
-- Name: mission_id_mission_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.mission_id_mission_seq', 1, false);


--
-- Name: mission_id_mission_seq1; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.mission_id_mission_seq1', 4, true);


--
-- Name: note_id_candidature_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.note_id_candidature_seq', 1, false);


--
-- Name: note_id_candidature_seq1; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.note_id_candidature_seq1', 1, false);


--
-- Name: poste_id_poste_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.poste_id_poste_seq', 1, false);


--
-- Name: poste_id_poste_seq1; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.poste_id_poste_seq1', 4, true);


--
-- Name: qualification_id_qualification_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.qualification_id_qualification_seq', 1, false);


--
-- Name: qualification_id_qualification_seq1; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.qualification_id_qualification_seq1', 7, true);


--
-- Name: question_id_question_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.question_id_question_seq', 1, false);


--
-- Name: question_id_question_seq1; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.question_id_question_seq1', 8, true);


--
-- Name: reponse_id_reponse_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.reponse_id_reponse_seq', 1, false);


--
-- Name: reponse_id_reponse_seq1; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.reponse_id_reponse_seq1', 17, true);


--
-- Name: service_id_service_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.service_id_service_seq', 1, false);


--
-- Name: service_id_service_seq1; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.service_id_service_seq1', 3, true);


--
-- Name: sexe_id_sexe_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.sexe_id_sexe_seq', 1, false);


--
-- Name: sexe_id_sexe_seq1; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.sexe_id_sexe_seq1', 2, true);


--
-- Name: situation_matrimoniale_id_situation_matrimoniale_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.situation_matrimoniale_id_situation_matrimoniale_seq', 1, false);


--
-- Name: situation_matrimoniale_id_situation_matrimoniale_seq1; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.situation_matrimoniale_id_situation_matrimoniale_seq1', 6, true);


--
-- Name: tache_id_tache_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tache_id_tache_seq', 1, false);


--
-- Name: tache_id_tache_seq1; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tache_id_tache_seq1', 6, true);


--
-- Name: type_avantage_id_avantage_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.type_avantage_id_avantage_seq', 1, false);


--
-- Name: type_avantage_id_avantage_seq1; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.type_avantage_id_avantage_seq1', 3, true);


--
-- Name: type_conge_id_type_conge_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.type_conge_id_type_conge_seq', 1, false);


--
-- Name: type_contrat_id_type_contrat_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.type_contrat_id_type_contrat_seq', 1, false);


--
-- Name: type_contrat_id_type_contrat_seq1; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.type_contrat_id_type_contrat_seq1', 3, true);


--
-- Name: type_salaire_id_type_salaire_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.type_salaire_id_type_salaire_seq', 1, false);


--
-- Name: annonce annonce_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.annonce
    ADD CONSTRAINT annonce_pkey PRIMARY KEY (id_annonce);


--
-- Name: candidat_cv candidat_cv_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.candidat_cv
    ADD CONSTRAINT candidat_cv_pkey PRIMARY KEY (id_candidat_cv);


--
-- Name: candidature candidature_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.candidature
    ADD CONSTRAINT candidature_pkey PRIMARY KEY (id_candidature);


--
-- Name: coefficient coefficient_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.coefficient
    ADD CONSTRAINT coefficient_pkey PRIMARY KEY (id_coefficient);


--
-- Name: conge_duree conge_duree_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.conge_duree
    ADD CONSTRAINT conge_duree_pkey PRIMARY KEY (id_conge_duree);


--
-- Name: conge conge_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.conge
    ADD CONSTRAINT conge_pkey PRIMARY KEY (id_conge);


--
-- Name: details_contrat details_contrat_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.details_contrat
    ADD CONSTRAINT details_contrat_pkey PRIMARY KEY (id_details_contrat);


--
-- Name: diplome diplome_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.diplome
    ADD CONSTRAINT diplome_pkey PRIMARY KEY (id_diplome);


--
-- Name: employe employe_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employe
    ADD CONSTRAINT employe_pkey PRIMARY KEY (id_employe);


--
-- Name: experience experience_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.experience
    ADD CONSTRAINT experience_pkey PRIMARY KEY (id_experience);


--
-- Name: horaire horaire_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.horaire
    ADD CONSTRAINT horaire_pkey PRIMARY KEY (id);


--
-- Name: jour jour_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.jour
    ADD CONSTRAINT jour_pkey PRIMARY KEY (id_jour);


--
-- Name: mission mission_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.mission
    ADD CONSTRAINT mission_pkey PRIMARY KEY (id_mission);


--
-- Name: note note_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.note
    ADD CONSTRAINT note_pkey PRIMARY KEY (id_candidature);


--
-- Name: poste poste_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.poste
    ADD CONSTRAINT poste_pkey PRIMARY KEY (id_poste);


--
-- Name: qualification qualification_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.qualification
    ADD CONSTRAINT qualification_pkey PRIMARY KEY (id_qualification);


--
-- Name: question question_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.question
    ADD CONSTRAINT question_pkey PRIMARY KEY (id_question);


--
-- Name: reponse reponse_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.reponse
    ADD CONSTRAINT reponse_pkey PRIMARY KEY (id_reponse);


--
-- Name: service service_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.service
    ADD CONSTRAINT service_pkey PRIMARY KEY (id_service);


--
-- Name: sexe sexe_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sexe
    ADD CONSTRAINT sexe_pkey PRIMARY KEY (id_sexe);


--
-- Name: situation_matrimoniale situation_matrimoniale_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.situation_matrimoniale
    ADD CONSTRAINT situation_matrimoniale_pkey PRIMARY KEY (id_situation_matrimoniale);


--
-- Name: tache tache_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tache
    ADD CONSTRAINT tache_pkey PRIMARY KEY (id_tache);


--
-- Name: type_avantage type_avantage_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.type_avantage
    ADD CONSTRAINT type_avantage_pkey PRIMARY KEY (id_avantage);


--
-- Name: type_conge type_conge_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.type_conge
    ADD CONSTRAINT type_conge_pkey PRIMARY KEY (id_type_conge);


--
-- Name: type_contrat type_contrat_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.type_contrat
    ADD CONSTRAINT type_contrat_pkey PRIMARY KEY (id_type_contrat);


--
-- Name: type_salaire type_salaire_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.type_salaire
    ADD CONSTRAINT type_salaire_pkey PRIMARY KEY (id_type_salaire);


--
-- Name: annonce annonce_id_service_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.annonce
    ADD CONSTRAINT annonce_id_service_fkey FOREIGN KEY (id_service) REFERENCES public.service(id_service);


--
-- Name: candidat_cv candidat_cv_id_candidature_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.candidat_cv
    ADD CONSTRAINT candidat_cv_id_candidature_fkey FOREIGN KEY (id_candidature) REFERENCES public.candidature(id_candidature);


--
-- Name: candidat_cv candidat_cv_id_diplome_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.candidat_cv
    ADD CONSTRAINT candidat_cv_id_diplome_fkey FOREIGN KEY (id_diplome) REFERENCES public.diplome(id_diplome);


--
-- Name: candidat_cv candidat_cv_id_sexe_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.candidat_cv
    ADD CONSTRAINT candidat_cv_id_sexe_fkey FOREIGN KEY (id_sexe) REFERENCES public.sexe(id_sexe);


--
-- Name: candidat_cv candidat_cv_id_situation_matrimoniale_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.candidat_cv
    ADD CONSTRAINT candidat_cv_id_situation_matrimoniale_fkey FOREIGN KEY (id_situation_matrimoniale) REFERENCES public.situation_matrimoniale(id_situation_matrimoniale);


--
-- Name: candidature candidature_id_annonce_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.candidature
    ADD CONSTRAINT candidature_id_annonce_fkey FOREIGN KEY (id_annonce) REFERENCES public.annonce(id_annonce);


--
-- Name: conge_duree conge_duree_id_type_conge_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.conge_duree
    ADD CONSTRAINT conge_duree_id_type_conge_fkey FOREIGN KEY (id_type_conge) REFERENCES public.type_conge(id_type_conge);


--
-- Name: conge conge_id_type_conge_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.conge
    ADD CONSTRAINT conge_id_type_conge_fkey FOREIGN KEY (id_type_conge) REFERENCES public.type_conge(id_type_conge);


--
-- Name: employe employe_id_candidature_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employe
    ADD CONSTRAINT employe_id_candidature_fkey FOREIGN KEY (id_candidature) REFERENCES public.candidature(id_candidature);


--
-- Name: entreprise entreprise_dirigeant_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.entreprise
    ADD CONSTRAINT entreprise_dirigeant_fkey FOREIGN KEY (dirigeant) REFERENCES public.employe(id_employe);


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
-- Name: candidat_cv fk_candidat_cv_experience; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.candidat_cv
    ADD CONSTRAINT fk_candidat_cv_experience FOREIGN KEY (id_experience) REFERENCES public.experience(id_experience);


--
-- Name: candidat_cv fk_candidat_cv_poste; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.candidat_cv
    ADD CONSTRAINT fk_candidat_cv_poste FOREIGN KEY (id_poste) REFERENCES public.poste(id_poste);


--
-- Name: details_contrat fk_details_contrat; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.details_contrat
    ADD CONSTRAINT fk_details_contrat FOREIGN KEY (id_type_contrat) REFERENCES public.type_contrat(id_type_contrat);


--
-- Name: details_contrat fk_details_contrat_employe; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.details_contrat
    ADD CONSTRAINT fk_details_contrat_employe FOREIGN KEY (id_employe) REFERENCES public.employe(id_employe);


--
-- Name: horaire fk_horaire_jour; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.horaire
    ADD CONSTRAINT fk_horaire_jour FOREIGN KEY (id_jour) REFERENCES public.jour(id_jour);


--
-- Name: mission fk_mission_poste; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.mission
    ADD CONSTRAINT fk_mission_poste FOREIGN KEY (id_mission) REFERENCES public.poste(id_poste);


--
-- Name: salaire fk_salaire_details_contrat; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.salaire
    ADD CONSTRAINT fk_salaire_details_contrat FOREIGN KEY (id_contrat) REFERENCES public.details_contrat(id_details_contrat);


--
-- Name: salaire fk_salaire_type_salaire; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.salaire
    ADD CONSTRAINT fk_salaire_type_salaire FOREIGN KEY (id_type_salaire) REFERENCES public.type_salaire(id_type_salaire);


--
-- Name: horaire horaire_id_contrat_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.horaire
    ADD CONSTRAINT horaire_id_contrat_fkey FOREIGN KEY (id_contrat) REFERENCES public.details_contrat(id_details_contrat);


--
-- Name: poste poste_id_service_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.poste
    ADD CONSTRAINT poste_id_service_fkey FOREIGN KEY (id_service) REFERENCES public.service(id_service);


--
-- Name: qualification qualification_id_annonce_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.qualification
    ADD CONSTRAINT qualification_id_annonce_fkey FOREIGN KEY (id_annonce) REFERENCES public.annonce(id_annonce);


--
-- Name: question question_id_annonce_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.question
    ADD CONSTRAINT question_id_annonce_fkey FOREIGN KEY (id_annonce) REFERENCES public.annonce(id_annonce);


--
-- Name: reponse reponse_id_question_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.reponse
    ADD CONSTRAINT reponse_id_question_fkey FOREIGN KEY (id_question) REFERENCES public.question(id_question);


--
-- PostgreSQL database dump complete
--

create table heure_supplementaire(
    matricule varchar(10) references details_contrat(matricule),
    dateDebut timestamp not null ,
    dateFin timestamp,
    mois int not null ,
    annee int not null 
);